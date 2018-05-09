using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ZXing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace ConsoleApp6
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Buffer<int> buffer = new Buffer<int>(10);
            var taskWrite = Task.Factory.StartNew(() =>
            {

                for (int i = 0; i < 20; i++)
                {
                    buffer.Write(i);
                    Console.WriteLine($"Write:i={i}");
                    Task.Delay(300).Wait();
                }
            });
            var taskRead = Task.Factory.StartNew(() =>
            {

                for (int i = 0; i < 7; i++)
                {
                    Console.WriteLine("Read:" + string.Join(",", buffer.Read()));
                    Task.Delay(1000).Wait();
                }
            });

            Task.WaitAll(taskWrite, taskRead);

        }
    }

    public class Buffer<T>
    {
        
        private T[] _TS;
        private byte _Index = 0;
        private int _Capcity;
        public Buffer(int capcity)
        {
            //将数组的大小设置成2的n次方
            while ((capcity & capcity - 1) != 0)
                capcity++;
            _TS = new T[capcity];
            _Capcity = capcity;
        }
        public void Write(T t)
        {
            _TS[_Index % _Capcity] = t;
            _Index++;
        }

        public IEnumerable<T> Read()
        {
            byte index = _Index;
            for (int i = 0; i < _TS.Count(); i++)
            {
                index--;
                yield return _TS[index % _Capcity];
            }
        }
    }
}
