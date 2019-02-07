using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Threading;
using ThreadingLib.Model;

namespace ThreadingLib.Service
{
    public class Working
    {
        /// <summary>
        /// Worker
        /// </summary>
        /// <param name="findYourGuid"></param>
        /// <returns></returns>
        public string ToDo(FindYourGuid findYourGuid)
        {
            return ToDo(findYourGuid, CancellationToken.None);
        }

        /// <summary>
        /// Worker
        /// </summary>
        /// <param name="findYourGuid"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public string ToDo(FindYourGuid findYourGuid, CancellationToken ct)
        {
            //measures time elapsed
            Stopwatch stopwatch = new Stopwatch();
            //start counting
            stopwatch.Start();

            int countLoop = 0;

            //output
            string result = string.Empty;

            do
            {
                string _guid = Guid.NewGuid().ToString();

                countLoop++;

                if (_guid.Count(c => c == findYourGuid.CharToFind) >= findYourGuid.HowManyTimes)
                {
                    var charArray = _guid.Select(c =>
                    {
                        char newChar = c != findYourGuid.CharToFind && c != '-' ? 'x' : c; return newChar;
                    });

                    string _guidChar = string.Concat(charArray);

                    result = $"\nSuccessful!\nThere were {countLoop} repetitions to find the Guid.\nOrigin: {_guid}\nSpotlight: {_guidChar}\nElapsed time: {stopwatch.Elapsed}\n";
                }

                if (ct.IsCancellationRequested)
                {
                    result = $"\nWork was canceled after {stopwatch.Elapsed}. {countLoop} repetitions.\n";
                }

                if (stopwatch.ElapsedMilliseconds >= findYourGuid.LimitTimeInMilliseconds)
                {
                    result = $"the time of {stopwatch.Elapsed} seconds is over. {countLoop} repetitions.";
                }
            }
            while (string.IsNullOrEmpty(result));

            //stop counting
            stopwatch.Stop();

            return result;
        }
    }
}
