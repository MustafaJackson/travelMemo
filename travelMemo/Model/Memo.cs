using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travelMemo.Model
{
    public class Memo
    {
        [PrimaryKey][Indexed][AutoIncrement]
        public int id { get; set; }
        public string memoName { get; set; }
        public string memoDetails { get; set; }


        //public Memo(string newMemoName, string newMemoDetails)
        //{
        //    memoName = newMemoName;
        //    memoDetails = newMemoDetails;
        //}
    }
}
