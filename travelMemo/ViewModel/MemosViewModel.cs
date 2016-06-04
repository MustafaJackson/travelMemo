using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelMemo.Model;

namespace travelMemo.ViewModel
{
    public class MemosViewModel
    {
        public ObservableCollection<Memo> MemoList;

        public string SaveItem(Memo item)
        {
            string result = string.Empty;
            using (var db = new SQLiteConnection(App.SQLITE_PLATFORM, App.DB_PATH))
            {
                try
                {
                    var existingItem = (db.Table<Memo>().Where(
                      c => c.id == item.id)).SingleOrDefault();
                    if (existingItem != null)
                    {
                        existingItem.memoName = item.memoName;
                        int success = db.Update(existingItem);
                    }
                    else
                    {
                        int success = db.Insert(new Memo()
                        {
                            memoName = item.memoName,
                            memoDetails = item.memoDetails
                        });
                    }
                    result = "Success";
                }
                catch
                {
                    result = "This item was not saved.";
                }
            }
            return result;
        }

        //public bool AddNewMemo(Memo newMemo)
        //{
        //    try
        //    {
        //        using (var db = new SQLiteConnection(App.SQLITE_PLATFORM, App.DB_PATH))
        //        {
        //            db.Insert(new Memo(newMemo.memoName, newMemo.memoDetails));
        //            MemoList.Add(newMemo);
        //            return true;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool deleteMemo(int memoId)
        //{
        //    bool result = false;
        //    using (var db = new SQLiteConnection(App.SQLITE_PLATFORM, App.DB_PATH))
        //    {
        //        var existingItem = db.Query<Memo>("select * from SomeModel where id =" + memoId).FirstOrDefault();
        //        if (existingItem != null)
        //        {
        //            db.RunInTransaction(() =>
        //            {

        //                db.Delete(existingItem);
        //                if (db.Delete(existingItem) > 0)
        //                {
        //                    result = true;
        //                }
        //                else
        //                {
        //                    result = false;
        //                }
        //            });
        //        }
        //        return result;
        //    }
        //}

        public ObservableCollection<Memo> GetItems()
        {
            MemoList = new ObservableCollection<Memo>();
            using (var db = new SQLiteConnection(App.SQLITE_PLATFORM, App.DB_PATH))
            {
                var query = db.Table<Memo>().OrderBy(c => c.id);
                foreach (var _item in query)
                {
                    var item = new Memo()
                    {
                        memoName = _item.memoName,
                        memoDetails = _item.memoDetails
                    };
                    MemoList.Add(item);
                }
            }
            return MemoList;

        }

    }
}
