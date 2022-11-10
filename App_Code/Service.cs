using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Web.Services;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Xml.Schema;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data.SqlClient;
using ClassKMBRWeb;
using System.Web.Services.Protocols;

//Rakhi S 17.12.2020
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    //public string getSankethamtoKBT(string LBID, string IKM_KBT_AuthorityName, string IKM_KBT_key)
    public string getSankethamtoKBT(string IKM_KBT_AuthorityName, string IKM_KBT_key)
    {
        KMBRWebDAO objKmbr = new KMBRWebDAO();
        DataSet ds = new DataSet();
        ArrayList arryIn = new ArrayList();
        //arryIn.Add(LBID);
        ds = objKmbr.execGet("[KBTFileStatus_S]", arryIn, "kmbrimage");
        string retXML = "";
        string retMainId = "";

        if (IKM_KBT_AuthorityName.ToString() == "IKMKBT" && IKM_KBT_key.ToString() == "to121LowoIbM4SYrRUrObmaUg==")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    retXML = retXML + ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    retMainId = retMainId + ds.Tables[0].Rows[i].ItemArray[0].ToString() + ",";
                }
                retXML = retXML.Replace("<IKMDETAILS>", "").Replace("</IKMDETAILS>", "");
                retXML = "<IKMDETAILS>" + retXML + "</IKMDETAILS>";
                if (retMainId.Length > 4)
                {
                    retMainId = retMainId + ")";
                    retMainId = retMainId.ToString().Replace(",)", ")");
                    string spName = "SET DATEFORMAT DMY UPDATE dbo.KBTFileStatus SET intFlag=1,dtmSent=getdate() WHERE intMain in(" + retMainId;
                    objKmbr.CheckTrasfered(spName, "kmbrimage");
                }
            }
            else
            {
                retXML = " No files from Kerala IKMDETAILS";
            }
        }
        else
        {
            retXML = " Please enter vaild AuthorityName and key";
        }
        return retXML;
    }

    //[WebMethod]
    //public string getSankethamtoKBTxml(string LBID, string IKM_KBT_AuthorityName, string IKM_KBT_key)
    //{
    //    KMBRWebDAO objKmbr = new KMBRWebDAO();
    //    DataSet ds = new DataSet();
    //    ArrayList arryIn = new ArrayList();
    //    arryIn.Add(LBID);
    //    ds = objKmbr.execGet("KBTMain_S", arryIn, "kmbrweb");
    //    string strxml = "";
       
    //    if (IKM_KBT_AuthorityName.ToString() == "IKMKBT" && IKM_KBT_key.ToString() == "to121LowoIbM4SYrRUrObmaUg==")
    //    {
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {

    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {
    //                XmlDocument doc = new XmlDocument();
    //                XmlDeclaration xmldecl;

    //                XmlElement H1 = doc.CreateElement("IKMDETAILS");
    //                XmlElement ND1 = doc.CreateElement("TOKBT");

    //                XmlElement ND2 = doc.CreateElement("application_details");
    //                XmlElement n1 = doc.CreateElement("reference_no");
    //                XmlElement n2 = doc.CreateElement("Localbody_no");
    //                XmlElement n3 = doc.CreateElement("OfficeId_no");

    //                n1.InnerText = ds.Tables[0].Rows[i][1].ToString();
    //                n2.InnerText = ds.Tables[0].Rows[i][2].ToString();
    //                n3.InnerText = ds.Tables[0].Rows[i][3].ToString();

    //                doc.AppendChild(H1);
    //                H1.AppendChild(ND1);

    //                ND1.AppendChild(ND2);
    //                ND2.AppendChild(n1);
    //                ND2.AppendChild(n2);
    //                ND2.AppendChild(n3);

    //                //------------------------------------------------------------------------------------------------------------//
    //                //applicant_details
    //                //------------------------------------------------------------------------------------------------------------//
    //                XmlElement ND3 = doc.CreateElement("applicant_details");

    //                XmlElement a1 = doc.CreateElement("applicant_name");
    //                XmlElement a2 = doc.CreateElement("house_name_number");
    //                XmlElement a3 = doc.CreateElement("address_line2");
    //                XmlElement a4 = doc.CreateElement("city");
    //                XmlElement a5 = doc.CreateElement("state");
    //                XmlElement a6 = doc.CreateElement("country");
    //                XmlElement a7 = doc.CreateElement("zip_code");
    //                XmlElement a8 = doc.CreateElement("comn_house_name_number");
    //                XmlElement a9 = doc.CreateElement("comn_address_line2");
    //                XmlElement a10 = doc.CreateElement("comn_city");
    //                XmlElement a11 = doc.CreateElement("comn_state");
    //                XmlElement a12 = doc.CreateElement("comn_country");
    //                XmlElement a13 = doc.CreateElement("comn_zip_code");
    //                XmlElement a14 = doc.CreateElement("mobile_no");
    //                //XmlElement a15 = doc.CreateElement("email_id");

    //                //Permanent Address
    //                arryIn.Clear();
    //                DataSet ds1 = new DataSet();
    //                arryIn.Add(Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString()));
    //                arryIn.Add(Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString()));
    //                arryIn.Add(Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString()));
    //                arryIn.Add(0);
    //                arryIn.Add(0);
    //                ds1 = objKmbr.execGet("AddressContact_S", arryIn, "kmbrweb");

    //                a1.InnerText = ds.Tables[0].Rows[i][4].ToString();
    //                a2.InnerText = ds1.Tables[0].Rows[0][3].ToString() + " [ " + ds1.Tables[0].Rows[0][21].ToString() + " ]";//chvHouseName,chvHouseNo
    //                a3.InnerText = ds1.Tables[0].Rows[0][5].ToString() + " [ " + ds1.Tables[0].Rows[0][4].ToString() + " ]";//chvResAssoc,chvResAssocNo
    //                a4.InnerText = ds1.Tables[0].Rows[0][8].ToString();
    //                a5.InnerText = ds1.Tables[0].Rows[0][17].ToString();
    //                a6.InnerText = ds1.Tables[0].Rows[0][19].ToString();
    //                a7.InnerText = ds1.Tables[0].Rows[0][10].ToString();
    //                a14.InnerText = ds1.Tables[0].Rows[0][12].ToString();


    //                //Communication Address
    //                arryIn.Clear();
    //                ds1.Clear();
    //                arryIn.Add(Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString()));
    //                arryIn.Add(Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString()));
    //                arryIn.Add(Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString()));
    //                arryIn.Add(1);
    //                arryIn.Add(0);
    //                ds1 = objKmbr.execGet("AddressContact_S", arryIn, "kmbrweb");

    //                a8.InnerText = ds1.Tables[0].Rows[0][3].ToString() + " [ " + ds1.Tables[0].Rows[0][21].ToString() + " ]";
    //                a9.InnerText = ds1.Tables[0].Rows[0][5].ToString() + " [ " + ds1.Tables[0].Rows[0][4].ToString() + " ]";//chvResAssoc,chvResAssocNo
    //                a10.InnerText = ds1.Tables[0].Rows[0][8].ToString();
    //                a11.InnerText = ds1.Tables[0].Rows[0][17].ToString();
    //                a12.InnerText = ds1.Tables[0].Rows[0][19].ToString();
    //                a13.InnerText = ds1.Tables[0].Rows[0][10].ToString();
    //                //a15.InnerText = ds.Tables[0].Rows[0][0].ToString();

    //                ND2.AppendChild(ND3);
    //                ND3.AppendChild(a1);
    //                ND3.AppendChild(a2);
    //                ND3.AppendChild(a3);
    //                ND3.AppendChild(a4);
    //                ND3.AppendChild(a5);
    //                ND3.AppendChild(a6);
    //                ND3.AppendChild(a7);
    //                ND3.AppendChild(a8);
    //                ND3.AppendChild(a9);
    //                ND3.AppendChild(a10);
    //                ND3.AppendChild(a11);
    //                ND3.AppendChild(a12);
    //                ND3.AppendChild(a13);
    //                ND3.AppendChild(a14);
    //                //ND3.AppendChild(a15);
    //                //---------------------------------------------------------------------------------------
    //                //Survey No.................
    //                //---------------------------------------------------------------------------------------
    //                XmlElement n4 = doc.CreateElement("Survey_No");
    //                arryIn.Clear();
    //                ds1.Clear();
    //                arryIn.Add(Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString()));
    //                arryIn.Add(Convert.ToInt32(ds.Tables[0].Rows[i][2].ToString()));
    //                arryIn.Add(Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString()));
    //                ds1 = objKmbr.execGet("KBT_SurveyNO_COMMON", arryIn, "kmbrweb");
    //                n4.InnerText = ds1.Tables[0].Rows[0][0].ToString();
    //                ND2.AppendChild(n4);
    //                //----------------------------------------------------------------------------------------
    //                XmlElement n5 = doc.CreateElement("District");
    //                n5.InnerText = ds.Tables[0].Rows[i][23].ToString();
    //                ND2.AppendChild(n5);

    //                XmlElement n6 = doc.CreateElement("Taluk");
    //                n6.InnerText = ds.Tables[0].Rows[i][21].ToString();
    //                ND2.AppendChild(n6);

    //                XmlElement n7 = doc.CreateElement("Village");
    //                n7.InnerText = ds.Tables[0].Rows[i][22].ToString();
    //                ND2.AppendChild(n7);

    //                XmlElement n8 = doc.CreateElement("Local_body_Name");
    //                n8.InnerText = ds.Tables[0].Rows[i][13].ToString();
    //                ND2.AppendChild(n8);

    //                XmlElement n9 = doc.CreateElement("Date_of_Completion");
    //                n9.InnerText = ds.Tables[0].Rows[i][19].ToString();
    //                ND2.AppendChild(n9);

    //                XmlElement n10 = doc.CreateElement("Date_of_Occupancy");
    //                n10.InnerText = ds.Tables[0].Rows[i][20].ToString();
    //                ND2.AppendChild(n10);

    //                //------------------------------------------------------------------------------------------------------------//
    //                //drawing_details
    //                //------------------------------------------------------------------------------------------------------------//
    //                XmlElement dr1 = doc.CreateElement("building_plan");

    //                ArrayList aryPath = new ArrayList();
    //                DataSet dspath = new DataSet();
    //                aryPath.Add(4);
    //                aryPath.Add(ds.Tables[0].Rows[0][1].ToString());
    //                dspath = this.Serverpath(aryPath);
    //                String AttPath1 = dspath.Tables[0].Rows[0][5].ToString();
    //                string strpathpdf = "";
    //                byte[] imageBytes = new byte[0];
    //                string base64String = "";

    //                wsimage.Service objimg = new wsimage.Service();
    //                objimg.Url = ConfigurationManager.AppSettings["wsimage.Service"].ToString();

    //                //Building Plan PDF
    //                DataSet dsPlan;
    //                string SqlNt = " SELECT numFileID, ImageName1 FROM dbo.SImages WHERE  numFileID = " + ds.Tables[0].Rows[0][1].ToString() + " and flgFile = 1 AND TypeID = 4";
    //                dsPlan = objKmbr.getSearchList(SqlNt, "kmbrweb");
    //                if (dsPlan.Tables[0].Rows.Count > 0)
    //                {
    //                    strpathpdf = AttPath1 + dsPlan.Tables[0].Rows[0][1].ToString() + ".pdf";
    //                    imageBytes = objimg.getimages(strpathpdf);
    //                    base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);

    //                    dr1.InnerText = base64String;
    //                }
    //                else //Building Plan Image
    //                {

    //                    ArrayList aryImage = new ArrayList();
    //                    //aryImage.Add(ds.Tables[0].Rows[i][1].ToString());
    //                    //aryImage.Add(ds.Tables[0].Rows[i][2].ToString());
    //                    //aryImage.Add(ds.Tables[0].Rows[i][3].ToString());
    //                    aryImage.Add(110000146);
    //                    aryImage.Add(173);
    //                    aryImage.Add(3017301);

    //                    byte[] bytes = FillBuildingPlanImageShareFolder(aryImage);
    //                    base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
    //                    dr1.InnerText = base64String;
    //                }
    //                ND2.AppendChild(dr1);

    //                //----------------------------------------------------------------------------
    //                XmlElement n11 = doc.CreateElement("Nature_of_Construction");
    //                KMBRWebDAO.ConnectionString = ConfigurationManager.AppSettings["connstrMaster"].ToString();

    //                KMBRWebDAO daoSanketham = new KMBRWebDAO();
    //                DataSet dspram = new DataSet();
    //                ArrayList arrInpram = new ArrayList();
    //                arrInpram.Add(ds.Tables[0].Rows[i][1].ToString());
    //                arrInpram.Add(ds.Tables[0].Rows[i][2].ToString());
    //                dspram = daoSanketham.execGet("ConsolidateCDTP_DMainId", arrInpram, "kmbrweb");
    //                n11.InnerText = dspram.Tables[0].Rows[0][4].ToString();
    //                ND2.AppendChild(n11);
    //                //------------------------------------------------------------------------------

    //                XmlElement n12 = doc.CreateElement("Nature_of_Building");
    //                //Nature of Building (1.Residential)
    //                dsPlan.Clear();
    //                SqlNt = "SELECT [numMain],[intLB],[intZone],[intBuilding],[intAI] FROM [MB_Occupancy_TR] WHERE (numMain =" + ds.Tables[0].Rows[0][1].ToString() + ")AND intLB = " + ds.Tables[0].Rows[0][2].ToString() + " AND ([intAI] =1 OR [intA2]=1) AND [intB] =0 AND [intC] =0 AND [intD] = 0 AND [intE] = 0 AND [intF] = 0 AND [intGI] = 0 AND [intG2] = 0 AND [intH] = 0 AND  [intI1] = 0 AND [intI2] = 0";
    //                dsPlan = objKmbr.getSearchList(SqlNt, "kmbrweb");

    //                //Nature of Building (2.Other than Residential)
    //                DataSet dsPlan1 = new DataSet();
    //                SqlNt = "SELECT [numMain],[intLB],[intZone],[intBuilding],[intAI] FROM [MB_Occupancy_TR] WHERE (numMain =" + ds.Tables[0].Rows[0][1].ToString() + ")AND intLB = " + ds.Tables[0].Rows[0][2].ToString() + " AND [intAI] =0 AND [intA2]=0 AND ([intB] =1 OR [intC] =1 OR [intD] = 1 OR [intE] = 1 OR [intF] = 1 OR [intGI] = 1 OR [intG2] = 1 OR [intH] = 1 OR  [intI1] = 1 OR [intI2] = 1  ) ";
    //                dsPlan1 = objKmbr.getSearchList(SqlNt, "kmbrweb");

    //                //Nature of Building (3. Residential + Other than Residential)
    //                DataSet dsPlan2 = new DataSet();
    //                SqlNt = "SELECT [numMain],[intLB],[intZone],[intBuilding],[intAI] FROM [MB_Occupancy_TR] WHERE (numMain =" + ds.Tables[0].Rows[0][1].ToString() + ")AND intLB = " + ds.Tables[0].Rows[0][2].ToString() + " AND ([intAI] =1 OR [intA2]=1) AND ([intB] =1 OR [intC] =1 OR [intD] = 1 OR [intE] = 1 OR [intF] = 1 OR [intGI] = 1 OR [intG2] = 1 OR [intH] = 1 OR  [intI1] = 1 OR [intI2] = 1  ) ";
    //                dsPlan2 = objKmbr.getSearchList(SqlNt, "kmbrweb");

    //                if (dsPlan.Tables[0].Rows.Count > 0)
    //                {
    //                    n12.InnerText = "1";
    //                }
    //                else if (dsPlan1.Tables[0].Rows.Count > 0)
    //                {
    //                    n12.InnerText = "2";
    //                }
    //                else if (dsPlan2.Tables[0].Rows.Count > 0)
    //                {
    //                    n12.InnerText = "3";
    //                }
    //                else
    //                {
    //                }
    //                ND2.AppendChild(n12);

    //                //-----------------------------------------------------------------------------------------------
    //                //Approved residential building area (Plinth)
    //                XmlElement n13 = doc.CreateElement("residential_building_area");
    //                n13.InnerText = ds.Tables[0].Rows[i][26].ToString();

    //                //Residential building area after completion
    //                XmlElement n14 = doc.CreateElement("residential_building_Completion_area");
    //                n14.InnerText = ds.Tables[0].Rows[i][28].ToString();

    //                //Approved other than residential building area
    //                XmlElement n15 = doc.CreateElement("Other_building_area");
    //                n15.InnerText = ds.Tables[0].Rows[i][27].ToString();

    //                //Other than residential building area after completion
    //                XmlElement n16 = doc.CreateElement("Other_building_Completion_area");
    //                n16.InnerText = ds.Tables[0].Rows[i][29].ToString();

    //                ND2.AppendChild(n13);
    //                ND2.AppendChild(n14);
    //                ND2.AppendChild(n15);
    //                ND2.AppendChild(n16);

    //                //------------------------------------------------------------------------------------------------
    //                strxml = doc.InnerXml.ToString();

    //                if (doc.InnerXml != "")
    //                {
    //                    xmldecl = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
    //                    XmlElement root = doc.DocumentElement;
    //                    doc.InsertBefore(xmldecl, root);

    //                    StringWriter sw = new StringWriter();
    //                    XmlTextWriter tx = new XmlTextWriter(sw);
    //                    doc.WriteTo(tx);
    //                    strxml = sw.ToString();// 
    //                }
    //                else
    //                {
    //                    //StringWriter sw1 = new StringWriter();
    //                    //XmlTextWriter tx1 = new XmlTextWriter(sw1);
    //                    //XmlDocument xd = new XmlDocument();
    //                    //xd.LoadXml(strxml);
    //                    DataTable dt = new DataTable("Rec");
    //                    dt.Columns.Add("SankethamApplication", typeof(string));
    //                    dt.Rows.Add(strxml.ToString());
    //                    DataSet ds2 = new DataSet();
    //                    ds2.Tables.Add(dt);
    //                    using (StringWriter sw1 = new StringWriter())
    //                        if (ds2.Tables[0].Rows.Count > 0)
    //                        {
    //                            {
    //                                ds2.WriteXml(sw1, XmlWriteMode.WriteSchema);//to sw
    //                                strxml = sw1.ToString();
    //                            }
    //                        }
    //                }
    //                //-------------------Save XML--------------------------------------------------

    //                ArrayList aryXML = new ArrayList();
    //                aryXML.Add(ds.Tables[0].Rows[i][1].ToString());
    //                aryXML.Add(ds.Tables[0].Rows[i][2].ToString());
    //                aryXML.Add(ds.Tables[0].Rows[i][3].ToString());
    //                aryXML.Add(strxml);
    //                daoSanketham.execSp("KBTFileStatus_I", aryXML, "kmbrimage");
    //                //----------------------------------------------------------------------------
    //            }
    //        }
    //        else
    //        {
    //            strxml = "No Data Found";
    //        }
    //    }
    //    else
    //    {
    //        strxml = " Please enter vaild AuthorityName and key";
    //    }
    //    ds.Clear();
    //    arryIn.Clear();
    //    arryIn.Add(LBID);
    //    ds = objKmbr.execGet("KBTFileStatus_S", arryIn, "kmbrimage");

       
    //    return strxml;
    //}
    //private DataSet Serverpath(ArrayList aryIn)
    //{

    //    KMBRWebDAO daoSanketham = new KMBRWebDAO();
    //    DataSet ds = new DataSet();
    //    ds = daoSanketham.execGet("M_Server_MainId", aryIn, "kmbrimage");
    //    return ds;
    //}
    //public byte[] FillBuildingPlanImageShareFolder(ArrayList aryIn) //4
    //{

    //    KMBRWebDAO daoSanketham = new KMBRWebDAO();
    //    DataSet ds = new DataSet();
    //    DataSet dsImage = new DataSet();
    //    Phrase blank = new Phrase("\n");

    //    byte[] bytesImg = null;
    //    Document pdfDoc = new Document(PageSize.A4.Rotate(), 5f, 5f, 5f, 0f);
    //    using (MemoryStream memoryStream = new MemoryStream())
    //    {
    //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
    //        pdfDoc.Open();

    //        aryIn.Add("4");
    //        dsImage = daoSanketham.execGet("MOgetPermitCompletionImageShareFolder_RPT", aryIn, "kmbrimage");
    //        if (dsImage.Tables.Count > 0)
    //        {
    //            if (dsImage.Tables[0].Rows.Count > 0)
    //            {

    //                ArrayList aryPath = new ArrayList();
    //                DataSet dspath = new DataSet();
    //                aryPath.Add(1);
    //                aryPath.Add(aryIn[0]);
    //                dspath = this.Serverpath(aryPath);
    //                String AttPath = dspath.Tables[0].Rows[0][5].ToString();
    //                string filepath1 = AttPath + aryIn[0].ToString() + "\\" + aryIn[0].ToString() + "-BuildingPlan.jpeg";

    //                wsimage.Service objimg = new wsimage.Service();
    //                objimg.Url = ConfigurationManager.AppSettings["wsimage.Service"].ToString();
    //                byte[] imageBytes = objimg.getimages(filepath1);


    //                string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);

    //                //----------------------------------------
    //                using (System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(imageBytes)))
    //                {
    //                    //System.Drawing.Image rezImage = this.resizeImage(System.Drawing.Image.FromStream(new MemoryStream(imageBytes)), new System.Drawing.Size(1800, 950));
    //                    iTextSharp.text.Image imgGraph = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
    //                    imgGraph.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
    //                    imgGraph.ScalePercent(40f);
    //                    pdfDoc.Add(imgGraph);
    //                }
    //                PdfContentByte content = writer.DirectContent;

    //                content.Stroke();
    //                pdfDoc.Close();

    //                //----------------------------------------

    //            }
    //            else
    //            {
    //                pdfDoc.Add(new Paragraph("No Data"));
    //            }
    //        }
    //        else
    //        {
    //            pdfDoc.Add(new Paragraph("No Data"));
    //        }

    //        pdfDoc.Close();
    //        bytesImg = memoryStream.ToArray();
    //        memoryStream.Close();

    //        return bytesImg;

    //    }
    //}
}
