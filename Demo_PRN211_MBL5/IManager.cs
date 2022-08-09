using System.Collections.Generic;

namespace Demo_PRN211_MBL5
{
    public interface IManager
    {
        void addList(int index);
        void showEmployee();
        void updateList();
        int isCodeExisted(string code);
        void delete();
        void saveFile();
        void loadFile();
    }
}