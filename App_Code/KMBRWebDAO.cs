using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ClassKMBRWeb
{
    public class KMBRWebDAO : KMBRWebDAObase
    {
        #region Methods

        public DataSet Provide_S(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("LM_Provide_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }

        public DataSet BuildingComplection(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("BuildingCompletion_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }


        public DataSet GetSoochikaFilebyFileStatus(int FileStatus, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(FileStatus);
            ds = FetchNew("FileNoFromSoochikabyFileStatus", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }

        public DataSet GetFee(long MainId, int LBId, int PanchaCat, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(MainId);
            arrIn.Add(LBId);
            arrIn.Add(PanchaCat);
            ds = FetchNew("Fee_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetZone(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("Zone_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet LBsettingCount(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("LBSettingCount", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetDistrictArch(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_LBDistrict_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetDistrict(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_LBDistrict_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetTalukReveniew(int TalukID, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(TalukID);
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_TalukReveniew_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetLBType(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_LBType_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetLBbyLBTypeDist(int LBType, int District, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(LBType);
            arrIn.Add(District);
            ds = FetchNew("spGM_LBName_S1", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetPostOfficeByDistrict(int districtId, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(districtId);
            ds = FetchNew("SpGM_PostOffice_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public int GetPinCode(int postOfficeId, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrPOParam = new ArrayList();
            int pinCode = 0;
            arrPOParam.Add(postOfficeId);

            ds = FetchNew("SpGM_PostOffice_S1", CommandType.StoredProcedure, arrPOParam, dbselect);
            if (ds.Tables[0].Rows.Count > 0)
            {
                pinCode = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
            }
            return pinCode;
        }
        public DataSet GetConstructionNature(int TypeId, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(TypeId);
            ds = FetchNew("ConstructionNatureGet", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetFloor(int FloorCount, int CellurFloor, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(FloorCount);
            arrIn.Add(CellurFloor);
            ds = FetchNew("FloorGetByFloorNo", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetOwnershipNature(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("OwnershipNatureGet", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetRuleBuildKPBR(int BuildStatus, int Well, int Wall, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(BuildStatus);
            arrIn.Add(Well);
            arrIn.Add(Wall);
            ds = FetchNew("RuleBuildingSelByBuildStatusKPBR1", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetRuleBuild(int BuildStatus, int Well, int Wall, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(BuildStatus);
            arrIn.Add(Well);
            arrIn.Add(Wall);
            ds = FetchNew("RuleBuildingSelByBuildStatus1", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetUsertype(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_UserType_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetTaluk(int District, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(District);
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_Taluk_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet Getlocalbody(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_Localbody_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetlocalbodybyDistrict(int districtId, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(districtId);
            ds = FetchNew("spGM_Localbody_S1", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet Getuser(int UserTypeId, int DistrictId, int LBId, int Zone, int WardId, string user, string pwd, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(UserTypeId);
            arrIn.Add(DistrictId);
            arrIn.Add(LBId);
            arrIn.Add(Zone);
            arrIn.Add(WardId);
            arrIn.Add(user);
            arrIn.Add(pwd);
            DataSet ds = new DataSet();
            ds = FetchNew("UserGet", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetSeatUserMapbyLB(int LBId, long User, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(LBId);
            arrIn.Add(User);
            DataSet ds = new DataSet();
            ds = FetchNew("SeatUserMap_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetSeatWardMapbyLB(int LBId, long Seat, int usertype, int subtype, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(LBId);
            arrIn.Add(Seat);
            arrIn.Add(usertype);
            arrIn.Add(subtype);
            DataSet ds = new DataSet();
            ds = FetchNew("SeatWardMap_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetWardbyLB(int LBId, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(LBId);
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_Ward_S4", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetUserSelect(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("UserSel", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetSeatNo(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("SeatsGet", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetInfraStructFacility(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("InfraStructFacilityGet", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetBuilding(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("BuildingTypeGet", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetBuildingDetails(int BuildId, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(BuildId);
            ds = FetchNew("BuildingDetailseGetbyBuild", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetFileNoByPermit(int PermitType, int imonth, int iYear, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(PermitType);
            arrIn.Add(imonth);
            arrIn.Add(iYear);
            ds = FetchNew("FileNoByPermitType", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;

        }

        public DataSet GetFileNoMain(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("FileNowithMainId", CommandType.StoredProcedure, dbselect);
            return ds;

        }
        public DataSet GetFileNoPermit(int Filestatus, string dbselect)
        {

            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Filestatus);
            ds = FetchNew("FileNoPermit", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetDesignation(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("GM_Designation_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetLoginUserDBM(string username, string pwd, string dbselect)
        {
            ArrayList arrIN = new ArrayList();
            arrIN.Add(username);
            arrIN.Add(pwd);
            DataSet ds = new DataSet();
            ds = FetchNew("SpGM_User_S2", CommandType.StoredProcedure, arrIN, dbselect);
            return ds;
        }
        public DataSet GetLoginUser(string username, string pwd, string dbselect)
        {
            ArrayList arrIN = new ArrayList();
            arrIN.Add(username);
            arrIN.Add(pwd);
            DataSet ds = new DataSet();
            ds = FetchNew("LoginDetails", CommandType.StoredProcedure, arrIN, dbselect);
            return ds;
        }
        public DataSet FillQuestionnaires(int Type, string dbselect)
        {
            ArrayList arrIN = new ArrayList();
            arrIN.Add(Type);
            DataSet ds = new DataSet();
            ds = FetchNew("Questionnaires_S", CommandType.StoredProcedure, arrIN, dbselect);
            return ds;
        }
        public DataSet FillLivingRoom(int intCount, int LBId, long MainId, string dbselect)
        {
            ArrayList arrIN = new ArrayList();
            arrIN.Add(intCount);
            arrIN.Add(LBId);
            arrIN.Add(MainId);
            DataSet ds = new DataSet();
            ds = FetchNew("Livingroom_S", CommandType.StoredProcedure, arrIN, dbselect);
            return ds;
        }
        public DataSet GetFillPloat(int count, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(count);
            DataSet ds = new DataSet();
            ds = FetchNew("PloatDetailCount", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetCivicStatus(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("CivicStatus_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetTownSize(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("TownSize_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetEmployeeNature(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("Employment_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetSocialGroup(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("SocialGroup_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetConstructionType(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("ConstructionType_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetLatrineFacility(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("Latrinefacility_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetBathroomFacility(int TypeID, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(TypeID);
            DataSet ds = new DataSet();
            ds = FetchNew("Bathroomfacility_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetDrinkingWater(int TypeID, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(TypeID);
            DataSet ds = new DataSet();
            ds = FetchNew("DrinkingWater_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetLightiningFacility(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("Lightingfacility_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetDistance(int TypeID, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(TypeID);
            DataSet ds = new DataSet();
            ds = FetchNew("Distance_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetLandCategory(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("LandMark_S", CommandType.StoredProcedure, dbselect);
            return ds;

        }
        public DataSet GetElectricCategory(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("ElectricityConnection_S", CommandType.StoredProcedure, dbselect);
            return ds;

        }
        public DataSet GetSoochikaLBWard(long MainID, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(MainID);
            DataSet ds = new DataSet();
            ds = FetchNew("Soochika_SLB", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetDesigName(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("BuildDesig_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetNameDesignation(int Usertype, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Usertype);
            DataSet ds = new DataSet();
            ds = FetchNew("NameDesignation_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;

        }

        public DataSet GetName(int UserID, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(UserID);
            DataSet ds = new DataSet();
            ds = FetchNew("Name_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetReveniewVillage(int DistrictID, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(DistrictID);
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_ReveniewVillage_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }

        public DataSet GetVillage(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("VillageSel", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetStatus(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("StatusMain", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetReceiptRow1(int LbType, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(LbType);
            DataSet ds = new DataSet();
            ds = FetchNew("ReceiptRows", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetReceiptRowByType(int DebitId, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(DebitId);
            DataSet ds = new DataSet();
            ds = FetchNew("ReceiptRowsByType", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetInwardDetails(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("Last10Inwards", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetDebit(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("Debit_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetTransaction(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("TransactionType_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetKMBRReceipt(int LBID, long MainID, int FileStatus, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(LBID);
            arrIn.Add(MainID);
            arrIn.Add(FileStatus);
            DataSet ds = new DataSet();
            ds = FetchNew("KMBRDetReceipt", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }

        public DataSet GetApproveRegistration(long main, int lb, long Zone, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(main);
            arrIn.Add(lb);
            arrIn.Add(Zone);
            ds = FetchNew("ApproveRegistration", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }

        public DataSet GetOccupancy(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("Occupancy_Get", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet SubRegistrarGet(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_SubRegistrarGet", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet AddOwnerGet(long intMain, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(intMain);
            ds = FetchNew("AddOwner_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }

        public DataSet OwnerGet(long Main, int Catid, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Main);
            arrIn.Add(Catid);
            ds = FetchNew("OwnerDetails_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet BuildingGet(int intOccpancyType, int intOther, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(intOccpancyType);
            arrIn.Add(intOther);
            ds = FetchNew("LM_Building_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet ZoneGet(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("LM_ZoneD_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet getSurveyResitrict(int VillageId, int SurveyNo, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(VillageId);
            arrIn.Add(SurveyNo);
            DataSet ds = new DataSet();
            ds = FetchNew("SurveyRestrict_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetZoneDiscription(int VillageId, int SurveyNo, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(VillageId);
            arrIn.Add(SurveyNo);
            DataSet ds = new DataSet();
            ds = FetchNew("ZoneDescription_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }

        public DataSet GetChapter(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("KMBRRulesChapter_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }

        public DataSet GetHead(int ChapterId, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(ChapterId);
            DataSet ds = new DataSet();
            ds = FetchNew("KMBRRulesHead_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }

        public DataSet GetSubHead(int ChapterId, int HeadId, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(ChapterId);
            arrIn.Add(HeadId);
            DataSet ds = new DataSet();
            ds = FetchNew("KMBRRulesSubhead_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }

        public DataSet GetRuleDesription(int ChapterId, int HeadId, int SubheadId, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(ChapterId);
            arrIn.Add(HeadId);
            arrIn.Add(SubheadId);
            DataSet ds = new DataSet();
            ds = FetchNew("KMBRRulesDiscription_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetEmpIdDesgId(int Zone, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Zone);
            DataSet ds = new DataSet();
            ds = FetchNew("LM_UserEmpnameID", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetKUserType(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("UserTypeLM_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }

        //public DataSet GetFee()
        //{
        //    DataSet ds = new DataSet();
        //    ds = FetchNew("FeeLM_S", CommandType.StoredProcedure,dbselect);
        //    return ds;
        //}
        public DataSet GetZonalOffice(int lbId, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(lbId);
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_Zone_S1", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetDesgId(int Zone, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Zone);
            DataSet ds = new DataSet();
            ds = FetchNew("LM_UserDesigId", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }

        public DataSet GetDispDTP(int Type, int Dist, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Type);
            arrIn.Add(Dist);
            DataSet ds = new DataSet();
            ds = FetchNew("DTPScheme_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetMeasurementUnit(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("MeasurementUnit_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetConvertResult(int Unit, double Value, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Unit);
            arrIn.Add(Value);
            DataSet ds = new DataSet();
            ds = FetchNew("ConvertResult", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet CUpdateSoochikaFlag(long MainId, int LBId, int ZoneId, int Flag, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(MainId);
            arrIn.Add(LBId);
            arrIn.Add(ZoneId);
            arrIn.Add(Flag);
            DataSet ds = new DataSet();
            ds = FetchNew("SoochikaFlag_U", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetUserFromMaster(int UserId, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(UserId);
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_UserSelect", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetZoneFromMaster(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_Zone_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetUserType1(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("spGMUserType_S1", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetUserDBM(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("GM_User_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetHISRegistration(long MainId, int flagId, string dbselect)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(MainId);
            arrin.Add(flagId);
            DataSet ds = new DataSet();
            ds = FetchNew("HISRegistration_TR_Save", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }

        public DataSet GetHISFloorDetails(long MainId, int flagId, string dbselect)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(MainId);
            arrin.Add(flagId);
            DataSet ds = new DataSet();
            ds = FetchNew("HisFloorDetails_TC_Save", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        public DataSet GetHISPloatDetails(long MainId, int flagId, string dbselect)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(MainId);
            arrin.Add(flagId);
            DataSet ds = new DataSet();
            ds = FetchNew("HisPloatDetails_TC_Save", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        public DataSet GetHisCheck(long MainId, int flagId, string dbselect)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(MainId);
            arrin.Add(flagId);
            DataSet ds = new DataSet();
            ds = FetchNew("HisCheck_TR_Save", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        public DataSet GetHisCheckBuildingDetails(long MainId, int flagId, string dbselect)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(MainId);
            arrin.Add(flagId);
            DataSet ds = new DataSet();
            ds = FetchNew("HisCheckBuildingDetails_TC_Save", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        public DataSet GetAdminLogin(string username, string pwd, string dbselect)
        {
            ArrayList arrIN = new ArrayList();
            arrIN.Add(username);
            arrIN.Add(pwd);
            DataSet ds = new DataSet();
            ds = FetchNew("AdminDetails", CommandType.StoredProcedure, arrIN, dbselect);
            return ds;
        }
        public DataSet GetHisNameAddress(long MainId, int flagId, string dbselect)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(MainId);
            arrin.Add(flagId);
            DataSet ds = new DataSet();
            ds = FetchNew("HisNameAddress_Save", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        public DataSet GetUserDisplay(int usertype, int zone, string dbselect)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(usertype);
            arrin.Add(zone);
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_UserDisplay_S", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        public DataSet GetFIFO(long Main, int SooFlag, int RegFlag, int CKlistFlag, int PermitType, string dbselect)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(Main);
            arrin.Add(SooFlag);
            arrin.Add(RegFlag);
            arrin.Add(CKlistFlag);
            arrin.Add(PermitType);
            DataSet ds = new DataSet();
            ds = FetchNew("FIFOMethod", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        public DataSet getRejection(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_Reject_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet getSubRegistrars(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_SubRegistrar_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet getFARDeduction(int Cellarid, int Floorid, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Cellarid);
            arrIn.Add(Floorid);
            ds = FetchNew("FARDeduction", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet UpdateSoochikaBitFlag(long MainId, int LBId, int ZoneId, int Flag, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(MainId);
            arrIn.Add(LBId);
            arrIn.Add(ZoneId);
            arrIn.Add(Flag);
            DataSet ds = new DataSet();
            ds = FetchNew("SoochikaOneDayFlag_U", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet UpdateRegistrationBitFlag(long MainId, int LBId, int ZoneId, int Flag, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(MainId);
            arrIn.Add(LBId);
            arrIn.Add(ZoneId);
            arrIn.Add(Flag);
            DataSet ds = new DataSet();
            ds = FetchNew("RegistrationOneDayFlag_U", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet UpdateregistrationFileStatus(long main, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(main);
            DataSet ds = new DataSet();
            ds = FetchNew("RejectRegistration", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet UpdateCheckListFileStatus(long main, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(main);
            DataSet ds = new DataSet();
            ds = FetchNew("RejectCheckOneDayPermit", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet RecieptTRSelFlag(long main, int lbid, int zoneid, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(main);
            arrIn.Add(lbid);
            arrIn.Add(zoneid);
            DataSet ds = new DataSet();
            ds = FetchNew("RecieptTRSelFlag", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet DemandNoGet(long main, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(main);
            DataSet ds = new DataSet();
            ds = FetchNew("DemandNo_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet LBNameOfficeGet(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("ZoneLBName_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet MonthGet(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("SELECT tnyCalMonthID,chvMonthEng FROM GM_Month", CommandType.Text, dbselect);
            return ds;
        }
        public DataSet YearGet(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("SELECT intYear,intYear AS year1 FROM GM_Year WHERE (intYear > 2008)ORDER BY intYear DESC", CommandType.Text, dbselect);
            return ds;
        }
        public DataSet FileNoPermitByTypedt(int itype, int imonth, int iyear, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(itype);
            arrIn.Add(imonth);
            arrIn.Add(iyear);
            DataSet ds = new DataSet();
            ds = FetchNew("FileNoPermitByTypeDt", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetPermitSerialNo(long main, int lb, long zone, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(main);
            arrIn.Add(lb);
            arrIn.Add(zone);
            DataSet ds = new DataSet();
            ds = FetchNew("PermitSlnoG", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetZoneName(long UserId, int LBId, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(UserId);
            arrIn.Add(LBId);
            DataSet ds = new DataSet();
            ds = FetchNew("GM_Zone_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet Getdts(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("DTSTable_Sel", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet Pushdata(int LBID, int ZoneID, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(LBID);
            arrIn.Add(ZoneID);
            DataSet ds = new DataSet();
            ds = FetchNew("DTSTable_Ins", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet UpdateProcess(int LBID, int ZoneID, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(LBID);
            arrIn.Add(ZoneID);
            DataSet ds = new DataSet();
            ds = FetchNew("DTSUpdateProcess1", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet UpdateDtsFlag(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("DTSUpdateFlag", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public int InsertDataWS(ArrayList arr, string dbselect)
        {
            int result = 0;
            result = SaveNew("DTSTempI1", CommandType.StoredProcedure, arr, dbselect);
            return result;
        }
        public DataSet UpdateData(int LB, int Zone, long Main, string dbselect)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(LB);
            arrin.Add(Zone);
            arrin.Add(Main);
            DataSet ds = new DataSet();
            ds = FetchNew("DTSSplitFromDTSTemp", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        public DataSet UpdateDTSTemp(int LB, int Zone, long Main, string dbselect)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(LB);
            arrin.Add(Zone);
            arrin.Add(Main);
            DataSet ds = new DataSet();
            ds = FetchNew("DTSUpdatePFlag1", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        public DataSet GetReasonGen(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("ReasonToGeneral_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet DtsFileStatus(int LBId, int ZoneId, int FileStatus, int DTSFlag, string dbselect)
        {
            ArrayList arr = new ArrayList();
            arr.Add(LBId);
            arr.Add(ZoneId);
            arr.Add(FileStatus);
            arr.Add(DTSFlag);
            DataSet ds = new DataSet();
            ds = FetchNew("DtsFileStatus", CommandType.StoredProcedure, arr, dbselect);
            return ds;
        }
        public DataSet GetCountry(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("Country_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetStateDistrict(int Type, int State, int District, string dbselect)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Type);
            arr.Add(State);
            arr.Add(District);
            DataSet ds = new DataSet();
            ds = FetchNew("StateDistrict_S", CommandType.StoredProcedure, arr, dbselect);
            return ds;
        }

        public DataSet GetWard2000withZone(int Zone, int Lb, string dbselect)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Zone);
            arr.Add(Lb);
            DataSet ds = new DataSet();
            ds = FetchNew("spGM_Ward_S2000Zonewise", CommandType.StoredProcedure, arr, dbselect);
            return ds;
        }
        public DataSet SetContactAddress(long main, string dbselect)
        {
            ArrayList arr = new ArrayList();
            arr.Add(main);
            DataSet ds = new DataSet();
            ds = FetchNew("AddContAddressSaankeya", CommandType.StoredProcedure, arr, dbselect);
            return ds;
        }
        public DataSet DemandApproval(long main, int LBId, long ZoneId, string dbselect)
        {
            ArrayList arr = new ArrayList();
            arr.Add(main);
            arr.Add(LBId);
            arr.Add(ZoneId);
            DataSet ds = new DataSet();
            ds = FetchNew("Demanded", CommandType.StoredProcedure, arr, dbselect);
            return ds;
        }
        public DataSet CheckTrasfered(string sQuery, string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew(sQuery, CommandType.Text, dbselect);
            return ds;
        }
        //public DataSet GetCheckCashPermitted(int LBId, int ZoneId, int main,string dbselect)
        //{
        //    ArrayList arr = new ArrayList();
        //    arr.Add(LBId);
        //    arr.Add(ZoneId);
        //    arr.Add(main);
        //    DataSet ds = new DataSet();
        //    ds = FetchNew("CheckCashPermitted", CommandType.StoredProcedure, arr,dbselect);
        //    return ds;
        //}
        public DataSet GetCheckCashPermitted(int LBId, long ZoneId, long main, string dbselect)
        {
            ArrayList arr = new ArrayList();
            arr.Add(LBId);
            arr.Add(ZoneId);
            arr.Add(main);
            DataSet ds = new DataSet();
            ds = FetchNew("CheckReceiptNoDate", CommandType.StoredProcedure, arr, dbselect);
            return ds;
        }
        public DataSet GetApproveCheckList(long main, int lb, long Zone, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(main);
            arrIn.Add(lb);
            arrIn.Add(Zone);
            ds = FetchNew("ApproveCheckList", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }

        public DataSet GetFileStatus(string sQuery, string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew(sQuery, CommandType.Text, dbselect);
            return ds;
        }
        public DataSet WardSeatUser(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("WardSeatUser_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet ReportingSeat(int Ward, int UserType, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Ward);
            arrIn.Add(UserType);
            ds = FetchNew("SeatToReport_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetUserBySeat(long Seat, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Seat);
            ds = FetchNew("UserIdbySeatId_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetVillageByDistTaluk(int DistId, int TalukId, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(DistId);
            arrIn.Add(TalukId);
            DataSet ds = new DataSet();
            ds = FetchNew("Village_S_DistTaluk", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetSubRegistrarByDist(int DistId, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(DistId);
            DataSet ds = new DataSet();
            ds = FetchNew("LM_RegistrarOfficeByDistId", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetLGType(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("LGTYpe_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetLGByDistLGType(int DistId, int LGtype, int LbCat, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(DistId);
            arrIn.Add(LGtype);
            arrIn.Add(LbCat);
            DataSet ds = new DataSet();
            ds = FetchNew("LocalGovByDistIdType_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }

        public DataSet GetARQualification(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("AR_Qualification_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetARDesignation(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("AR_Designation_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetARTypeEmployer(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("AR_TypeEmployer_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetARBirthProof(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("AR_BirthProof_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet ViewArchitectRegistration(int IssuedPlace, int UserType, int LicenceHold, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(IssuedPlace);
            arrIn.Add(UserType);
            arrIn.Add(LicenceHold);
            DataSet ds = new DataSet();
            ds = FetchNew("SpArchitectRegistration_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        //public DataSet ViewArchitectRegistration(int Lb,string dbselect)
        //{
        //    ArrayList arrIn = new ArrayList();
        //    arrIn.Add(Lb);
        //    DataSet ds = new DataSet();
        //    ds = FetchNew("ArchitectRegistration_S", CommandType.StoredProcedure, arrIn,dbselect);
        //    return ds;
        //}
        public DataSet UserCount(ArrayList arrin, string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("_SP_UserCount_S", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }

        public DataSet ValidateUser(ArrayList arrin, string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("_Sp_ValidateUser", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        public DataSet GetLoginStatus(ArrayList arrin, string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("_Sp_GetLoginStatus", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        public void UpdateUserReg(string query, string dbselect)
        {
            FetchNew(query, CommandType.Text, dbselect);
        }
        public void InsertUser(ArrayList arrin, string dbselect)
        {
            FetchNew("_SP_InsertUser_I", CommandType.StoredProcedure, arrin, dbselect);
        }


        public void execSp(string SpName, ArrayList arrIn, string dbselect)
        {
            SaveNew(SpName, CommandType.StoredProcedure, arrIn, dbselect);
        }
        

        public DataSet execGet(string SpName, ArrayList arrIn, string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew(SpName, CommandType.StoredProcedure, arrIn,dbselect);
            return ds;
            
        }
        
        public DataSet GetLSataus(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("LStatus_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetPAction(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("PAction_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetArchitectDetailsForPermit(int UserRegistration, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(UserRegistration);
            DataSet ds = new DataSet();
            ds = FetchNew("ArchitectDetailsForPermit", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetOfficerLogin(string User, string Password, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(User);
            arrIn.Add(Password);
            DataSet ds = new DataSet();
            ds = FetchNew("LoginOfficer", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetArchitectRejected(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("ArchitectRejected_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet GetBuildingRules(int BuildingType, string TestContaint, string dbselect)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(BuildingType);
            arrIn.Add(TestContaint);
            DataSet ds = new DataSet();
            ds = FetchNew("GM_RuleBuild", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetRegNo(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("RegNo", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public void UpdateUserRegFileStatus(string query, string dbselect)
        {
            FetchNew(query, CommandType.Text, dbselect);
        }
        public DataSet GetArchitectPlace(string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew("GM_ArchitectPlace_S", CommandType.StoredProcedure, dbselect);
            return ds;
        }
        //*****************Begin Syalima*****************
        public DataSet execGetSpOnly(string SpName, string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew(SpName, CommandType.StoredProcedure, dbselect);
            return ds;
        }
        public DataSet getSubRegistrarsbyDist(int DistId, string dbselect)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(DistId);
            DataSet ds = new DataSet();
            ds = FetchNew("LM_RegistrarOfficeByDistId", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        //************End Syalima*********************

        public DataSet GetMaps(int DistId, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(DistId);
            ds = FetchNew("GM_Maps_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet SetFARCoverage(int Table, int LbType, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Table);
            arrIn.Add(LbType);
            ds = FetchNew("FARCoverage_S", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }
        public DataSet GetAddtionalfee(int intId, int intTypeId, string dbselect)
        {
            ArrayList arrin = new ArrayList();
            arrin.Add(intId);
            arrin.Add(intTypeId);
            DataSet ds = new DataSet();
            ds = FetchNew("AddtionalFee_S", CommandType.StoredProcedure, arrin, dbselect);
            return ds;
        }
        public DataSet getSearchList(string strSql, string dbselect)
        {
            DataSet ds = new DataSet();
            ds = FetchNew(strSql, CommandType.Text, dbselect);
            return ds;
        }
        public DataSet ViewImage(ArrayList ArrIn, string dbselect)
        {

            DataSet ds = new DataSet();
            ds = FetchNew("SImages_S", CommandType.StoredProcedure, ArrIn, dbselect);
            return ds;
        }
        public DataSet BuildingGet26Above(int intOccpancyType, int intOther, string dbselect)
        {
            DataSet ds = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(intOccpancyType);
            arrIn.Add(intOther);
            ds = FetchNew("LM_Building_S26Above", CommandType.StoredProcedure, arrIn, dbselect);
            return ds;
        }

        public int ExecEditSP(string sp, ArrayList arrIn, string dbselect)//LBL
        {
            int k = 0;
            k = EditNew(sp, CommandType.StoredProcedure, arrIn, dbselect);
            return k;
        }
        public int ExecByteQUERY(string sqlQuery, string k1, byte[] bytes, string dbselect)//LBL (06/06/2015)
        {
            int k = 0;
            k = insertQueryNew(sqlQuery, k1, bytes, "kmbrweb");
            return k;
        }

        #endregion
    }
}
