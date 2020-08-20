using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SalaryAssist.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SalaryAssist.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 

        public MainModel mainModel { get; set; }
        public List<string> fullNameList { get; set; }
        public RelayCommand LoadFileCMD { get; set; }
       

        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ///
            mainModel = new MainModel();
            mainModel.FullNameList = new List<string>();
            LoadFileCMD = new RelayCommand(LoadFile);
        }

        private void LoadFile()
        {
            string path="";
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog()==DialogResult.OK)
            {
                path = folder.SelectedPath;
            }
            fullNameList = new List<string>();
            Director(path, fullNameList);
            mainModel.FullNameList = fullNameList;


        }
        public void Director(string dir, List<string> list)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            FileInfo[] files = d.GetFiles();//文件
            DirectoryInfo[] directs = d.GetDirectories();//文件夹
            foreach (FileInfo f in files)
            {
                list.Add(f.Name);//添加文件名到列表中  
            }
            //获取子文件夹内的文件列表，递归遍历  
            foreach (DirectoryInfo dd in directs)
            {
                Director(dd.FullName, list);
            }
        }
    }
}