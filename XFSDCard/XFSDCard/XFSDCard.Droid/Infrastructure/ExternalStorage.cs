using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XFSDCard.Infrastructure;
using System.IO;
using XFSDCard.Droid.Infrastructure;

[assembly: Xamarin.Forms.Dependency(typeof(ExternalStorage))]
namespace XFSDCard.Droid.Infrastructure
{
    public class ExternalStorage : IExternalStorage
    {
        public string Read(string path, string filename)
        {
            var fooResult = "";

            // Gets the current state of the primary "external" storage device.
            if (Android.OS.Environment.ExternalStorageState == Android.OS.Environment.MediaMounted)
            {
                var foo = Android.OS.Environment.GetExternalStoragePublicDirectory("");
                var fooFullPath2 = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, path);
                // �T�{�o�ӥؿ��O�_�s�b
                if (Directory.Exists(fooFullPath2) == false)
                {
                    return "";
                }
                else
                {
                    // �զX�̲צ��ɮצW�٪�������|
                    var fooFilenamex = Path.Combine(fooFullPath2, filename);
                    if (File.Exists(fooFilenamex) == true)
                    {
                        // �q�ɮפ�Ū���X���e
                        fooResult = File.ReadAllText(fooFilenamex);
                    }
                }
            }
            return fooResult;
        }

        public bool Write(string path, string filename, string content)
        {
            var fooResult = false;

            // Gets the current state of the primary "external" storage device.
            if (Android.OS.Environment.ExternalStorageState == Android.OS.Environment.MediaMounted)
            {
                // �զX�̲ק�����|
                var fooFullPath2 = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, path);
                // �T�{�o�ӥؿ��O�_�s�b
                if(Directory.Exists(fooFullPath2) == false)
                {
                    // ���s�b�A�h���ͥ�
                    Directory.CreateDirectory(fooFullPath2);
                }
                // �զX�̲צ��ɮצW�٪�������|
                var fooFilenamex = Path.Combine(fooFullPath2, filename);
                //�N���e�g�J�ɮפ�
                File.WriteAllText(fooFilenamex, content);
            }

            return fooResult;
        }
    }
}