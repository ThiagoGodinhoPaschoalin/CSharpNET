namespace ThreadingLib.Model
{
    public class FindYourGuid
    {
        /// <summary>
        /// What char you like to find in Guid?
        /// </summary>
        public char CharToFind { get; set; }

        /// <summary>
        /// How many time you like to find this char?
        /// </summary>
        public int HowManyTimes { get; set; }

        /// <summary>
        /// Limit time to find the char. if elapsed time > this, get out!
        /// </summary>
        public long LimitTimeInMilliseconds { get; set; }

        public FindYourGuid(char CharToFind, int HowManyTimes, long LimitTimeInMilliseconds)
        {
            this.CharToFind = CharToFind;
            this.HowManyTimes = HowManyTimes;
            this.LimitTimeInMilliseconds = LimitTimeInMilliseconds;
        }
    }
}
