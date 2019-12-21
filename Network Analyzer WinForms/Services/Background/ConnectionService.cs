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
    ///     Background connection service for updating connections in database
    /// </summary>
    public class ConnectionService
    {
        private readonly object m_TimerTreatmentConnectionsLock = new object();

        private readonly BackendServce _backendServce;

        private readonly Timer m_TimerTreatmentConnections;

        public ConnectionService()
        {
            m_TimerTreatmentConnections = new Timer();
            m_TimerTreatmentConnections.Tick += TimerTreatmentConnections_Tick;

            _backendServce = BackendServce.GetService();
        }

        /// <summary>
        ///     Start treatment connections
        /// </summary>
        public void StartService()
        {
            m_TimerTreatmentConnections.Start();
        }

        /// <summary>
        ///     Stop treatment service
        /// </summary>
        public void StopService()
        {
            m_TimerTreatmentConnections.Stop();
        }

        /// <summary>
        ///     Treatment connections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTreatmentConnections_Tick(object sender, EventArgs e)
        {
            if (!Monitor.TryEnter(m_TimerTreatmentConnectionsLock))
            {
                return;
            }

            try
            {
                List<ConnectionModel> connections = Connections.GetConnections();

                // Create all connections in database
                for (int i = 0; i < connections.Count; i++)
                {
                    if (connections[i].DatabaseId == 0)
                    {
                        ConnectionViewModel connection = _backendServce.CreateConnectionAsync(new ConnectionEditReqModel
                        {
                            Created = DateTime.Now,
                            SourceAddress = connections[i].SourceAddress,
                            DestinationAddress = connections[i].DestinationAddress
                        }).Result;

                        connections[i].DatabaseId = connection.Id;
                    }
                }

                // Create all connection packets in database
                for (int i = 0; i < connections.Count; i++)
                {
                    if (connections[i].DatabaseId == 0)
                    {
                        continue;
                    }

                    int treatmentConnecionPacketCounter = 0;

                    for (int j = 0; j < connections[i].ConnectionPackets.Count; j++)
                    {
                        if (connections[i].ConnectionPackets[j].DatabaseId == 0)
                        {
                            ConnectionPacketViewModel connectionPacket = _backendServce.CreateConnectionPacketAsync(
                                connections[i].DatabaseId, new ConnectionPacketEditReqModel
                                {
                                    Data = connections[i].ConnectionPackets[j].Data,
                                    Type = ConnectionPacketType.ClientToServer
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

                // Disconnect connection packets in database
                for (int i = 0; i < connections.Count; i++)
                {
                    if (connections[i].DatabaseId == 0)
                    {
                        continue;
                    }

                    if (connections[i].IsDisconnected && connections[i].IsDisconnected == false)
                    {
                        _backendServce.CloseConnectionAsync(connections[i].DatabaseId);
                        connections[i].IsDatabaseDisconnected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                StopService();
                //lblInformation.Text = Localizer.LocalizeString("Main.ErrorsSavingConnections");
            }
            finally
            {
                Monitor.Exit(m_TimerTreatmentConnectionsLock);
            }
        }
    }
}