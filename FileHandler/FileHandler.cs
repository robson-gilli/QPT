using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandler
{
    public class FileHandler
    {
        private string _path;
        public FileHandler(string path)
        {
            _path = path;
        }

        public void WriteTask(string content, string fileName)
        {
            Task.Run(() =>
            {
                byte[] encodedText = Encoding.Default.GetBytes(content); 

                using (FileStream sourceStream = new FileStream(_path + fileName,
                    FileMode.Append, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true))
                {
                    sourceStream.Write(encodedText, 0, encodedText.Length);
                }
            });
        }

        public async Task WriteAsync(string content, string fileName)
        {

            byte[] encodedText = Encoding.Default.GetBytes(content);    //   .Unicode.GetBytes(content);

            using (FileStream sourceStream = new FileStream(_path + fileName,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            }
            //using (StreamWriter writer = new StreamWriter(_path + fileName, true))
            //{
            //    await writer.WriteAsync(content);
            //}
        }

        public void Write(string content, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(_path + fileName, true))
            {
                writer.Write(content);
            }
        }

        public async Task<List<Tuple<string, string>>> ListFileAsync()
        {
            List<Tuple<string, string>> files = new List<Tuple<string, string>>();
            DirectoryInfo downloadedMessageInfo = new DirectoryInfo(_path);

            try
            {
                await Task.Run(() =>
                {
                    foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                    {
                        Tuple<string, string> f = Tuple.Create(file.Name, new TimeSpan(DateTime.Now.Ticks).ToString());
                        files.Add(f);
                    }
                });
            }
            catch (Exception e)
            {
                throw e;
            }
            return files;
        }

        public void DeleteAll()
        {
            DirectoryInfo downloadedMessageInfo = new DirectoryInfo(_path);

            foreach (FileInfo file in downloadedMessageInfo.GetFiles())
            {
                file.Delete();
            }
        }

        public async Task DeleteAllAsync()
        {
            DirectoryInfo downloadedMessageInfo = new DirectoryInfo(_path);
            await Task.Run(() =>
            {
                foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                {
                    file.Delete();
                }
            });
        }

        public async Task DeleteFileAsync(string fileName)
        {
            DirectoryInfo downloadedMessageInfo = new DirectoryInfo(_path);
            await Task.Run(() =>
            {
                string path = _path + fileName;
                File.Delete(path);
            });
        }

        public async Task<string> OpenFileAsync(string fileName)
        {
            StringBuilder file = new StringBuilder();
            try
            {
                await Task.Run(() =>
                {
                    string path = _path + fileName;
                    using (FileStream fs = File.Open(path, FileMode.Open))
                    {
                        byte[] b = new byte[1024];
                        UTF8Encoding temp = new UTF8Encoding(true);

                        while (fs.Read(b, 0, b.Length) > 0)
                        {
                            file.Append(temp.GetString(b));
                        }
                    }
                });
            }
            catch (Exception e)
            {
                throw e;
            }
            return file.ToString();
        }

        public async Task WriteListAsync(List<Tuple<string, string>> messageList)
        {
            List<Task> tList = new List<Task>();
            foreach (Tuple<string, string> tuple in messageList)
            {
                Tuple<string, string> t = Tuple.Create(tuple.Item1, tuple.Item2);
                byte[] encodedText = Encoding.Default.GetBytes(t.Item2);    //   .Unicode.GetBytes(content);

                using (FileStream sourceStream = new FileStream(_path + t.Item1,
                    FileMode.Append, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true))
                {
                    tList.Add(sourceStream.WriteAsync(encodedText, 0, encodedText.Length));
                }

                //tList.Add(Task.Run(() =>
                //{
                //    byte[] encodedText = Encoding.Default.GetBytes(t.Item2);    //   .Unicode.GetBytes(content);
                //    using (FileStream sourceStream = new FileStream(_path + t.Item1,
                //        FileMode.Append, FileAccess.Write, FileShare.None,
                //        bufferSize: 4096, useAsync: true))
                //    {
                //        sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                //    }

                //}));
            }
            await Task.WhenAll(tList.ToArray());
        }

        public void WriteList(List<Tuple<string, string>> messageList)
        {
            List<Task> tList = new List<Task>();
            foreach (Tuple<string, string> tuple in messageList)
            {

                byte[] encodedText = Encoding.Default.GetBytes(tuple.Item2);    //   .Unicode.GetBytes(content);

                using (FileStream sourceStream = new FileStream(_path + tuple.Item1,
                    FileMode.Append, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true))
                {
                    sourceStream.Write(encodedText, 0, encodedText.Length);
                }
            }
        }
    }
}