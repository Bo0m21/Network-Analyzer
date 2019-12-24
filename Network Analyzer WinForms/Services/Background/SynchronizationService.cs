using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Network_Analyzer_WinForms.Models.Connection;
using Network_Analyzer_WinForms.Network;
using Timer = System.Windows.Forms.Timer;

namespace Network_Analyzer_WinForms.Services.Background
{
    /// <summary>
    ///     Background synchronization service for updating connections in database
    /// </summary>
    public class SynchronizationService
    {
        private static SynchronizationService _synchronizationService;

        private readonly object _timerSynchronizationLock = new object();
        private readonly Timer _timerSynchronization;

        private readonly BackendServce _backendServce;

        private bool _synchronizationStatus { get; set; }

        private SynchronizationService()
        {
            _timerSynchronization = new Timer();
            _timerSynchronization.Interval = 1000;
            _timerSynchronization.Tick += TimerSynchronizationTick;

            _backendServce = BackendServce.GetService();
        }

        /// <summary>
        ///     Get single service instance
        /// </summary>
        /// <returns></returns>
        public static SynchronizationService GetService()
        {
            if (_synchronizationService == null)
            {
                _synchronizationService = new SynchronizationService();
            }

            return _synchronizationService;
        }

        /// <summary>
        ///     Start synchronization connections
        /// </summary>
        public void StartSynchronization()
        {
            _timerSynchronization.Start();
        }

        /// <summary>
        ///     Stop synchronization service
        /// </summary>
        public void StopSynchronization()
        {
            _timerSynchronization.Stop();
        }

        /// <summary>
        ///     Get synchronization status
        /// </summary>
        /// <returns></returns>
        public bool GetSynchronizationStatus()
        {
            return _synchronizationStatus;
        }

        /// <summary>
        ///     Synchronization connections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerSynchronizationTick(object sender, EventArgs e)
        {
            if (!Monitor.TryEnter(_timerSynchronizationLock))
            {
                return;
            }

            try
            {
                List<ConnectionModel> connections = Connections.GetConnections();
                bool synchronizationStatus = true;

                // Synchronize all connections in database
                for (int i = 0; i < connections.Count; i++)
                {
                    if (connections[i].DatabaseId == 0)
                    {
                        synchronizationStatus = false;

                        ConnectionViewModel connection = _backendServce.CreateConnectionAsync(new ConnectionEditReqModel
                        {
                            Created = DateTime.Now,
                            SourceAddress = connections[i].SourceAddress,
                            DestinationAddress = connections[i].DestinationAddress
                        }).Result;

                        connections[i].DatabaseId = connection.Id;
                    }
                }

                // Synchronize all connection packets in database
                for (int i = 0; i < connections.Count; i++)
                {
                    if (connections[i].DatabaseId == 0)
                    {
                        synchronizationStatus = false;
                        continue;
                    }

                    int treatmentConnecionPacketCounter = 0;

                    for (int j = 0; j < connections[i].ConnectionPackets.Count; j++)
                    {
                        if (connections[i].ConnectionPackets[j].DatabaseId == 0)
                        {
                            synchronizationStatus = false;

                            ConnectionPacketViewModel connectionPacket = _backendServce.CreateConnectionPacketAsync(
                                connections[i].DatabaseId, new ConnectionPacketEditReqModel
                                {
                                    Data = connections[i].ConnectionPackets[j].Data,
                                    Type = connections[i].ConnectionPackets[j].Type == Models.Connection.ConnectionPacketType.ClientToServer ? ConnectionPacketType.ClientToServer : ConnectionPacketType.ServerToClient
                                }).Result;

                            connections[i].ConnectionPackets[j].DatabaseId = connectionPacket.Id;
                            treatmentConnecionPacketCounter++;

                            if (treatmentConnecionPacketCounter == 5)
                            {
                                break;
                            }
                        }
                    }
                }

                // Synchronize disconnect connection packets in database
                for (int i = 0; i < connections.Count; i++)
                {
                    if (connections[i].DatabaseId == 0)
                    {
                        synchronizationStatus = false;
                        continue;
                    }

                    if (connections[i].IsDisconnected && connections[i].IsDisconnected == false)
                    {
                        synchronizationStatus = false;

                        _backendServce.CloseConnectionAsync(connections[i].DatabaseId);
                        connections[i].IsDatabaseDisconnected = true;
                    }
                }

                _synchronizationStatus = synchronizationStatus;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
            finally
            {
                Monitor.Exit(_timerSynchronizationLock);
            }
        }
    }
}