using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSWord = Microsoft.Office.Interop.Word;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.IO;

namespace Section13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p = new Person();
            //p.Action(aim: "speak");
            //Com.WriteWord();
        }
    }

    public class Com
    {
        /*
         * 导入COM:1、找到office软件的安装目录且找到msword.olb文件 导入
         * 将com属性中的嵌入互操作类型改为false以及复制到本地改为true  可以在bin文件下生成动态库
         * **/
        public static void WriteWord()
        {
            MSWord.Application wordApp = new MSWord.Application();
            wordApp.Documents.Add(Visible: true);
            MSWord.Document doc = wordApp.ActiveDocument;
            MSWord.Paragraph para = doc.Paragraphs.Add();
            para.Range.Text = "Thank goodness for C# 4";
            object fileName = @"E:\demo.doc";
            object format = MSWord.WdSaveFormat.wdFormatDocument;
            doc.SaveAs(FileName: ref fileName, FileFormat: ref format);
            doc.Close();
            wordApp.Application.Quit();
        }
    }

    public class Person
    {
        public String Name { get; set; }
        public Int32 Age { get; set; }

        public void Action(String aim=null,String text=null)
        {
            Console.Write(aim ??
                text ??
                "NULL");
        }
    }
}
