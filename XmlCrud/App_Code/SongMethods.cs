using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml.Linq;

namespace XmlCrud.App_Code
{
    public class SongMethods
    {
        private DataSet ds = new DataSet("playlist");

        public DataSet GetAllSongs(string file)
        {
            //setup some datesets, tables and columns

            DataTable dtSongs = new DataTable("song");

            DataColumn dcId = new DataColumn("id");
            DataColumn dcArtist = new DataColumn("artist");
            DataColumn dcTitle = new DataColumn("title");
            DataColumn dcYear = new DataColumn("year");
            DataColumn dcGerne = new DataColumn("gerne");
            DataColumn dcTime = new DataColumn("time");
            DataColumn dcFile = new DataColumn("file");

            //connect objects to datasets, tables and columns
            dtSongs.Columns.Add(dcId);
            dtSongs.Columns.Add(dcArtist);
            dtSongs.Columns.Add(dcTitle);
            dtSongs.Columns.Add(dcYear);
            dtSongs.Columns.Add(dcGerne);
            dtSongs.Columns.Add(dcTime);
            dtSongs.Columns.Add(dcFile);

            //Read the data of XML file

            ds.ReadXml(HttpContext.Current.Server.MapPath(file));

            return ds;
        }
        public DataRow GetEmptyDataRow()
        {
            DataRow dr = ds.Tables["song"].NewRow();
            return dr;
        }
        //create new song
        public void CreateSong(DataRow dataRow, string file)
        {
            ds.Tables["song"].Rows.Add(dataRow);
            ds.WriteXml(HttpContext.Current.Server.MapPath(file));
        }

        //Delete song
        public void DeleteSong(string id, string file)
        {
            DataRow[] drArray = ds.Tables["song"].Select("id = '" + id + "'");
            if (drArray != null && drArray.Length > 0)
            {
                drArray[0].Delete();
                ds.WriteXml(HttpContext.Current.Server.MapPath(file));
            }
        }
        public void EditSong(string id, string file)
        {
            DataRow[] drArray = ds.Tables["song"].Select("id = '" + id + "'");
            if (drArray != null && drArray.Length > 0)
            {

                drArray[0].Delete();
                ds.WriteXml(HttpContext.Current.Server.MapPath(file));
            }
        }
    }
}