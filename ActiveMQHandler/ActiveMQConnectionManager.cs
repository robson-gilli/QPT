using Apache.NMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveMQHandler
{
    public class ActiveMQConnectionManager : ActiveMQClient
    {
        public struct ConnectionData
        {
            public IConnection iconnection;
            public bool inUse;
            public DateTime lastUse;
            public string id;
        }
//        private ConnectionData _connData;
        private static Dictionary<string, ConnectionData> _connList;
        private static object _mutex;
        private const int _timeout = 15000000;


        public ActiveMQConnectionManager(string queueUrl, string queueName)
            : base(queueUrl, queueName)
        {
        }

        static ActiveMQConnectionManager()
        {
            _mutex = new object();
            _connList = new Dictionary<string, ConnectionData>();
        }


        public ConnectionData getConnection()
        {
            ClearOldConnections();

            lock (_mutex)
            {
                ConnectionData cd = GetFirstAvailableConn();
                if (cd.iconnection != null)
                {
                    return cd;
                }
                else
                {
                    cd= GetNewConnection();
                    return cd;
                }
            }
        }


        private ConnectionData GetFirstAvailableConn()
        {
            ConnectionData cd = new ConnectionData();
            if (_connList.Count(x => x.Value.inUse == false) > 0)
            {
                lock (_mutex)
                {
                    if (_connList.Count(x => x.Value.inUse == false) > 0)
                    {
                        string key = _connList.First(x => x.Value.inUse == false).Key;
                        cd = _connList[key];
                        cd.inUse = true;
                        cd.lastUse = DateTime.Now;
                        _connList[key] = cd;

                        System.Diagnostics.Debug.WriteLine("Get available (" + cd.id + ") at: " + DateTime.Now.ToString("HH:mm:ss.ffff"));
                        System.Diagnostics.Debug.WriteLine("Total of: " + _connList.Count());
                    }
                }
            }
            return cd;
        }


        private ConnectionData GetNewConnection()
        {
            ConnectionData d = new ConnectionData();
            d.iconnection = _factory.CreateConnection();
            d.inUse = true;
            d.lastUse = DateTime.Now;
            d.id = Guid.NewGuid().ToString();
            lock (_mutex)
            {
                _connList.Add(d.id, d);
            }

            System.Diagnostics.Debug.WriteLine("Connection Manager created new connection(" + d.id + ") at: " + DateTime.Now.ToString("HH:mm:ss.ffff"));
            System.Diagnostics.Debug.WriteLine("Total of: " + _connList.Count());

            return d;
        }


        private void ClearOldConnections()
        {
            if (_connList.Count() > 0)
            {
                lock (_mutex)
                {
                    if (_connList.Count() > 0)
                    {

                        foreach (string key in _connList.Keys)
                        {
                            ConnectionData c = _connList[key];

                            if ((DateTime.Now - c.lastUse).Milliseconds >= _timeout)
                            {
                                c.iconnection.Stop();
                                c.iconnection.Close();
                                c.iconnection.Dispose();
                                _connList.Remove(key);

                                System.Diagnostics.Debug.WriteLine("Connection Manager Killed old connection(" + key + ") at: " + DateTime.Now.ToString("HH:mm:ss.ffff"));
                                System.Diagnostics.Debug.WriteLine("Total of: " + _connList.Count());
                            }
                        }
                    }
                }
            }
        }

        public void ReleaseConnection(ConnectionData c)
        {
            c.inUse = false;
            c.lastUse = DateTime.Now;
            lock (_mutex)
            {
                _connList[c.id] = c;
            }
            System.Diagnostics.Debug.WriteLine("Released (" + c.id + ") at: " + DateTime.Now.ToString("HH:mm:ss.ffff"));
            System.Diagnostics.Debug.WriteLine("Total of: " + _connList.Count());


        }

        public void ReleaseAll()
        {
            lock (_mutex)
            {
                foreach (string key in _connList.Keys)
                {
                    _connList[key].iconnection.Close();
                    _connList[key].iconnection.Dispose();
                    _connList.Remove(key);
                }
            }
        }

    }
}
