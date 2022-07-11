using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace PE2.DAL
{
    /// <summary>
    /// 数据访问类:v_Calibrate
    /// </summary>
    public partial class v_Calibrate
    {
        public v_Calibrate()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Assets_sn, string Assts_no, string Assts_id, string Assts_name, string Assts_eq_id, string Assts_eq_name, int Assts_Quantity, string Assts_Customer, int Place_sn, string Place_Assets_sn, string Place_Assets_Detail_sn, int LastUser_sn, DateTime LastChange_date, string Note, string SysNote, string Assts_Station, int Assts_Station_num, int Assts_Sttatus, string Place_name, string Floor, int Floor_sn, int Calibrate_sn, string Eq_id, string Eq_no, string Eq_name, string Eq_factory, string Eq_factory_no, string Eq_Assets_no, string Cp_Date_Range, DateTime Last_Cp_Date, DateTime Next_Cp_Date, string Cp_Place, string Cp_Type, string Cp_Note, string Cp_Note1, int Cp_Status, int Last_Cp_Log_sn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_Calibrate");
            strSql.Append(" where Assets_sn=@Assets_sn and Assts_no=@Assts_no and Assts_id=@Assts_id and Assts_name=@Assts_name and Assts_eq_id=@Assts_eq_id and Assts_eq_name=@Assts_eq_name and Assts_Quantity=@Assts_Quantity and Assts_Customer=@Assts_Customer and Place_sn=@Place_sn and Place_Assets_sn=@Place_Assets_sn and Place_Assets_Detail_sn=@Place_Assets_Detail_sn and LastUser_sn=@LastUser_sn and LastChange_date=@LastChange_date and Note=@Note and SysNote=@SysNote and Assts_Station=@Assts_Station and Assts_Station_num=@Assts_Station_num and Assts_Sttatus=@Assts_Sttatus and Place_name=@Place_name and Floor=@Floor and Floor_sn=@Floor_sn and Calibrate_sn=@Calibrate_sn and Eq_id=@Eq_id and Eq_no=@Eq_no and Eq_name=@Eq_name and Eq_factory=@Eq_factory and Eq_factory_no=@Eq_factory_no and Eq_Assets_no=@Eq_Assets_no and Cp_Date_Range=@Cp_Date_Range and Last_Cp_Date=@Last_Cp_Date and Next_Cp_Date=@Next_Cp_Date and Cp_Place=@Cp_Place and Cp_Type=@Cp_Type and Cp_Note=@Cp_Note and Cp_Note1=@Cp_Note1 and Cp_Status=@Cp_Status and Last_Cp_Log_sn=@Last_Cp_Log_sn ");
            SqlParameter[] parameters = {
					new SqlParameter("@Assets_sn", SqlDbType.Int,4),
					new SqlParameter("@Assts_no", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Quantity", SqlDbType.Int,4),
					new SqlParameter("@Assts_Customer", SqlDbType.NVarChar,500),
					new SqlParameter("@Place_sn", SqlDbType.Int,4),
					new SqlParameter("@Place_Assets_sn", SqlDbType.NVarChar,500),
					new SqlParameter("@Place_Assets_Detail_sn", SqlDbType.NVarChar,500),
					new SqlParameter("@LastUser_sn", SqlDbType.Int,4),
					new SqlParameter("@LastChange_date", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.NVarChar,500),
					new SqlParameter("@SysNote", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station_num", SqlDbType.Int,4),
					new SqlParameter("@Assts_Sttatus", SqlDbType.Int,4),
					new SqlParameter("@Place_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Floor", SqlDbType.NVarChar,50),
					new SqlParameter("@Floor_sn", SqlDbType.Int,4),
					new SqlParameter("@Calibrate_sn", SqlDbType.Int,4),
					new SqlParameter("@Eq_id", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_Assets_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Date_Range", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Next_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Cp_Place", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note1", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Status", SqlDbType.Int,4),
					new SqlParameter("@Last_Cp_Log_sn", SqlDbType.Int,4)			};
            parameters[0].Value = Assets_sn;
            parameters[1].Value = Assts_no;
            parameters[2].Value = Assts_id;
            parameters[3].Value = Assts_name;
            parameters[4].Value = Assts_eq_id;
            parameters[5].Value = Assts_eq_name;
            parameters[6].Value = Assts_Quantity;
            parameters[7].Value = Assts_Customer;
            parameters[8].Value = Place_sn;
            parameters[9].Value = Place_Assets_sn;
            parameters[10].Value = Place_Assets_Detail_sn;
            parameters[11].Value = LastUser_sn;
            parameters[12].Value = LastChange_date;
            parameters[13].Value = Note;
            parameters[14].Value = SysNote;
            parameters[15].Value = Assts_Station;
            parameters[16].Value = Assts_Station_num;
            parameters[17].Value = Assts_Sttatus;
            parameters[18].Value = Place_name;
            parameters[19].Value = Floor;
            parameters[20].Value = Floor_sn;
            parameters[21].Value = Calibrate_sn;
            parameters[22].Value = Eq_id;
            parameters[23].Value = Eq_no;
            parameters[24].Value = Eq_name;
            parameters[25].Value = Eq_factory;
            parameters[26].Value = Eq_factory_no;
            parameters[27].Value = Eq_Assets_no;
            parameters[28].Value = Cp_Date_Range;
            parameters[29].Value = Last_Cp_Date;
            parameters[30].Value = Next_Cp_Date;
            parameters[31].Value = Cp_Place;
            parameters[32].Value = Cp_Type;
            parameters[33].Value = Cp_Note;
            parameters[34].Value = Cp_Note1;
            parameters[35].Value = Cp_Status;
            parameters[36].Value = Last_Cp_Log_sn;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PE2.Model.v_Calibrate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into v_Calibrate(");
            strSql.Append("Assets_sn,Assts_no,Assts_id,Assts_name,Assts_eq_id,Assts_eq_name,Assts_Quantity,Assts_Customer,Place_sn,Place_Assets_sn,Place_Assets_Detail_sn,LastUser_sn,LastChange_date,Note,SysNote,Assts_Station,Assts_Station_num,Assts_Sttatus,Place_name,Floor,Floor_sn,Calibrate_sn,Eq_id,Eq_no,Eq_name,Eq_factory,Eq_factory_no,Eq_Assets_no,Cp_Date_Range,Last_Cp_Date,Next_Cp_Date,Cp_Place,Cp_Type,Cp_Note,Cp_Note1,Cp_Status,Last_Cp_Log_sn)");
            strSql.Append(" values (");
            strSql.Append("@Assets_sn,@Assts_no,@Assts_id,@Assts_name,@Assts_eq_id,@Assts_eq_name,@Assts_Quantity,@Assts_Customer,@Place_sn,@Place_Assets_sn,@Place_Assets_Detail_sn,@LastUser_sn,@LastChange_date,@Note,@SysNote,@Assts_Station,@Assts_Station_num,@Assts_Sttatus,@Place_name,@Floor,@Floor_sn,@Calibrate_sn,@Eq_id,@Eq_no,@Eq_name,@Eq_factory,@Eq_factory_no,@Eq_Assets_no,@Cp_Date_Range,@Last_Cp_Date,@Next_Cp_Date,@Cp_Place,@Cp_Type,@Cp_Note,@Cp_Note1,@Cp_Status,@Last_Cp_Log_sn)");
            SqlParameter[] parameters = {
					new SqlParameter("@Assets_sn", SqlDbType.Int,4),
					new SqlParameter("@Assts_no", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Quantity", SqlDbType.Int,4),
					new SqlParameter("@Assts_Customer", SqlDbType.NVarChar,500),
					new SqlParameter("@Place_sn", SqlDbType.Int,4),
					new SqlParameter("@Place_Assets_sn", SqlDbType.NVarChar,500),
					new SqlParameter("@Place_Assets_Detail_sn", SqlDbType.NVarChar,500),
					new SqlParameter("@LastUser_sn", SqlDbType.Int,4),
					new SqlParameter("@LastChange_date", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.NVarChar,500),
					new SqlParameter("@SysNote", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station_num", SqlDbType.Int,4),
					new SqlParameter("@Assts_Sttatus", SqlDbType.Int,4),
					new SqlParameter("@Place_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Floor", SqlDbType.NVarChar,50),
					new SqlParameter("@Floor_sn", SqlDbType.Int,4),
					new SqlParameter("@Calibrate_sn", SqlDbType.Int,4),
					new SqlParameter("@Eq_id", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_Assets_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Date_Range", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Next_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Cp_Place", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note1", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Status", SqlDbType.Int,4),
					new SqlParameter("@Last_Cp_Log_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.Assets_sn;
            parameters[1].Value = model.Assts_no;
            parameters[2].Value = model.Assts_id;
            parameters[3].Value = model.Assts_name;
            parameters[4].Value = model.Assts_eq_id;
            parameters[5].Value = model.Assts_eq_name;
            parameters[6].Value = model.Assts_Quantity;
            parameters[7].Value = model.Assts_Customer;
            parameters[8].Value = model.Place_sn;
            parameters[9].Value = model.Place_Assets_sn;
            parameters[10].Value = model.Place_Assets_Detail_sn;
            parameters[11].Value = model.LastUser_sn;
            parameters[12].Value = model.LastChange_date;
            parameters[13].Value = model.Note;
            parameters[14].Value = model.SysNote;
            parameters[15].Value = model.Assts_Station;
            parameters[16].Value = model.Assts_Station_num;
            parameters[17].Value = model.Assts_Sttatus;
            parameters[18].Value = model.Place_name;
            parameters[19].Value = model.Floor;
            parameters[20].Value = model.Floor_sn;
            parameters[21].Value = model.Calibrate_sn;
            parameters[22].Value = model.Eq_id;
            parameters[23].Value = model.Eq_no;
            parameters[24].Value = model.Eq_name;
            parameters[25].Value = model.Eq_factory;
            parameters[26].Value = model.Eq_factory_no;
            parameters[27].Value = model.Eq_Assets_no;
            parameters[28].Value = model.Cp_Date_Range;
            parameters[29].Value = model.Last_Cp_Date;
            parameters[30].Value = model.Next_Cp_Date;
            parameters[31].Value = model.Cp_Place;
            parameters[32].Value = model.Cp_Type;
            parameters[33].Value = model.Cp_Note;
            parameters[34].Value = model.Cp_Note1;
            parameters[35].Value = model.Cp_Status;
            parameters[36].Value = model.Last_Cp_Log_sn;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PE2.Model.v_Calibrate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update v_Calibrate set ");
            strSql.Append("Assets_sn=@Assets_sn,");
            strSql.Append("Assts_no=@Assts_no,");
            strSql.Append("Assts_id=@Assts_id,");
            strSql.Append("Assts_name=@Assts_name,");
            strSql.Append("Assts_eq_id=@Assts_eq_id,");
            strSql.Append("Assts_eq_name=@Assts_eq_name,");
            strSql.Append("Assts_Quantity=@Assts_Quantity,");
            strSql.Append("Assts_Customer=@Assts_Customer,");
            strSql.Append("Place_sn=@Place_sn,");
            strSql.Append("Place_Assets_sn=@Place_Assets_sn,");
            strSql.Append("Place_Assets_Detail_sn=@Place_Assets_Detail_sn,");
            strSql.Append("LastUser_sn=@LastUser_sn,");
            strSql.Append("LastChange_date=@LastChange_date,");
            strSql.Append("Note=@Note,");
            strSql.Append("SysNote=@SysNote,");
            strSql.Append("Assts_Station=@Assts_Station,");
            strSql.Append("Assts_Station_num=@Assts_Station_num,");
            strSql.Append("Assts_Sttatus=@Assts_Sttatus,");
            strSql.Append("Place_name=@Place_name,");
            strSql.Append("Floor=@Floor,");
            strSql.Append("Floor_sn=@Floor_sn,");
            strSql.Append("Calibrate_sn=@Calibrate_sn,");
            strSql.Append("Eq_id=@Eq_id,");
            strSql.Append("Eq_no=@Eq_no,");
            strSql.Append("Eq_name=@Eq_name,");
            strSql.Append("Eq_factory=@Eq_factory,");
            strSql.Append("Eq_factory_no=@Eq_factory_no,");
            strSql.Append("Eq_Assets_no=@Eq_Assets_no,");
            strSql.Append("Cp_Date_Range=@Cp_Date_Range,");
            strSql.Append("Last_Cp_Date=@Last_Cp_Date,");
            strSql.Append("Next_Cp_Date=@Next_Cp_Date,");
            strSql.Append("Cp_Place=@Cp_Place,");
            strSql.Append("Cp_Type=@Cp_Type,");
            strSql.Append("Cp_Note=@Cp_Note,");
            strSql.Append("Cp_Note1=@Cp_Note1,");
            strSql.Append("Cp_Status=@Cp_Status,");
            strSql.Append("Last_Cp_Log_sn=@Last_Cp_Log_sn");
            strSql.Append(" where Assets_sn=@Assets_sn and Assts_no=@Assts_no and Assts_id=@Assts_id and Assts_name=@Assts_name and Assts_eq_id=@Assts_eq_id and Assts_eq_name=@Assts_eq_name and Assts_Quantity=@Assts_Quantity and Assts_Customer=@Assts_Customer and Place_sn=@Place_sn and Place_Assets_sn=@Place_Assets_sn and Place_Assets_Detail_sn=@Place_Assets_Detail_sn and LastUser_sn=@LastUser_sn and LastChange_date=@LastChange_date and Note=@Note and SysNote=@SysNote and Assts_Station=@Assts_Station and Assts_Station_num=@Assts_Station_num and Assts_Sttatus=@Assts_Sttatus and Place_name=@Place_name and Floor=@Floor and Floor_sn=@Floor_sn and Calibrate_sn=@Calibrate_sn and Eq_id=@Eq_id and Eq_no=@Eq_no and Eq_name=@Eq_name and Eq_factory=@Eq_factory and Eq_factory_no=@Eq_factory_no and Eq_Assets_no=@Eq_Assets_no and Cp_Date_Range=@Cp_Date_Range and Last_Cp_Date=@Last_Cp_Date and Next_Cp_Date=@Next_Cp_Date and Cp_Place=@Cp_Place and Cp_Type=@Cp_Type and Cp_Note=@Cp_Note and Cp_Note1=@Cp_Note1 and Cp_Status=@Cp_Status and Last_Cp_Log_sn=@Last_Cp_Log_sn ");
            SqlParameter[] parameters = {
					new SqlParameter("@Assets_sn", SqlDbType.Int,4),
					new SqlParameter("@Assts_no", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Quantity", SqlDbType.Int,4),
					new SqlParameter("@Assts_Customer", SqlDbType.NVarChar,500),
					new SqlParameter("@Place_sn", SqlDbType.Int,4),
					new SqlParameter("@Place_Assets_sn", SqlDbType.NVarChar,500),
					new SqlParameter("@Place_Assets_Detail_sn", SqlDbType.NVarChar,500),
					new SqlParameter("@LastUser_sn", SqlDbType.Int,4),
					new SqlParameter("@LastChange_date", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.NVarChar,500),
					new SqlParameter("@SysNote", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station_num", SqlDbType.Int,4),
					new SqlParameter("@Assts_Sttatus", SqlDbType.Int,4),
					new SqlParameter("@Place_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Floor", SqlDbType.NVarChar,50),
					new SqlParameter("@Floor_sn", SqlDbType.Int,4),
					new SqlParameter("@Calibrate_sn", SqlDbType.Int,4),
					new SqlParameter("@Eq_id", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_Assets_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Date_Range", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Next_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Cp_Place", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note1", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Status", SqlDbType.Int,4),
					new SqlParameter("@Last_Cp_Log_sn", SqlDbType.Int,4)};
            parameters[0].Value = model.Assets_sn;
            parameters[1].Value = model.Assts_no;
            parameters[2].Value = model.Assts_id;
            parameters[3].Value = model.Assts_name;
            parameters[4].Value = model.Assts_eq_id;
            parameters[5].Value = model.Assts_eq_name;
            parameters[6].Value = model.Assts_Quantity;
            parameters[7].Value = model.Assts_Customer;
            parameters[8].Value = model.Place_sn;
            parameters[9].Value = model.Place_Assets_sn;
            parameters[10].Value = model.Place_Assets_Detail_sn;
            parameters[11].Value = model.LastUser_sn;
            parameters[12].Value = model.LastChange_date;
            parameters[13].Value = model.Note;
            parameters[14].Value = model.SysNote;
            parameters[15].Value = model.Assts_Station;
            parameters[16].Value = model.Assts_Station_num;
            parameters[17].Value = model.Assts_Sttatus;
            parameters[18].Value = model.Place_name;
            parameters[19].Value = model.Floor;
            parameters[20].Value = model.Floor_sn;
            parameters[21].Value = model.Calibrate_sn;
            parameters[22].Value = model.Eq_id;
            parameters[23].Value = model.Eq_no;
            parameters[24].Value = model.Eq_name;
            parameters[25].Value = model.Eq_factory;
            parameters[26].Value = model.Eq_factory_no;
            parameters[27].Value = model.Eq_Assets_no;
            parameters[28].Value = model.Cp_Date_Range;
            parameters[29].Value = model.Last_Cp_Date;
            parameters[30].Value = model.Next_Cp_Date;
            parameters[31].Value = model.Cp_Place;
            parameters[32].Value = model.Cp_Type;
            parameters[33].Value = model.Cp_Note;
            parameters[34].Value = model.Cp_Note1;
            parameters[35].Value = model.Cp_Status;
            parameters[36].Value = model.Last_Cp_Log_sn;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Assets_sn, string Assts_no, string Assts_id, string Assts_name, string Assts_eq_id, string Assts_eq_name, int Assts_Quantity, string Assts_Customer, int Place_sn, string Place_Assets_sn, string Place_Assets_Detail_sn, int LastUser_sn, DateTime LastChange_date, string Note, string SysNote, string Assts_Station, int Assts_Station_num, int Assts_Sttatus, string Place_name, string Floor, int Floor_sn, int Calibrate_sn, string Eq_id, string Eq_no, string Eq_name, string Eq_factory, string Eq_factory_no, string Eq_Assets_no, string Cp_Date_Range, DateTime Last_Cp_Date, DateTime Next_Cp_Date, string Cp_Place, string Cp_Type, string Cp_Note, string Cp_Note1, int Cp_Status, int Last_Cp_Log_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_Calibrate ");
            strSql.Append(" where Assets_sn=@Assets_sn and Assts_no=@Assts_no and Assts_id=@Assts_id and Assts_name=@Assts_name and Assts_eq_id=@Assts_eq_id and Assts_eq_name=@Assts_eq_name and Assts_Quantity=@Assts_Quantity and Assts_Customer=@Assts_Customer and Place_sn=@Place_sn and Place_Assets_sn=@Place_Assets_sn and Place_Assets_Detail_sn=@Place_Assets_Detail_sn and LastUser_sn=@LastUser_sn and LastChange_date=@LastChange_date and Note=@Note and SysNote=@SysNote and Assts_Station=@Assts_Station and Assts_Station_num=@Assts_Station_num and Assts_Sttatus=@Assts_Sttatus and Place_name=@Place_name and Floor=@Floor and Floor_sn=@Floor_sn and Calibrate_sn=@Calibrate_sn and Eq_id=@Eq_id and Eq_no=@Eq_no and Eq_name=@Eq_name and Eq_factory=@Eq_factory and Eq_factory_no=@Eq_factory_no and Eq_Assets_no=@Eq_Assets_no and Cp_Date_Range=@Cp_Date_Range and Last_Cp_Date=@Last_Cp_Date and Next_Cp_Date=@Next_Cp_Date and Cp_Place=@Cp_Place and Cp_Type=@Cp_Type and Cp_Note=@Cp_Note and Cp_Note1=@Cp_Note1 and Cp_Status=@Cp_Status and Last_Cp_Log_sn=@Last_Cp_Log_sn ");
            SqlParameter[] parameters = {
					new SqlParameter("@Assets_sn", SqlDbType.Int,4),
					new SqlParameter("@Assts_no", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Quantity", SqlDbType.Int,4),
					new SqlParameter("@Assts_Customer", SqlDbType.NVarChar,500),
					new SqlParameter("@Place_sn", SqlDbType.Int,4),
					new SqlParameter("@Place_Assets_sn", SqlDbType.NVarChar,500),
					new SqlParameter("@Place_Assets_Detail_sn", SqlDbType.NVarChar,500),
					new SqlParameter("@LastUser_sn", SqlDbType.Int,4),
					new SqlParameter("@LastChange_date", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.NVarChar,500),
					new SqlParameter("@SysNote", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station_num", SqlDbType.Int,4),
					new SqlParameter("@Assts_Sttatus", SqlDbType.Int,4),
					new SqlParameter("@Place_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Floor", SqlDbType.NVarChar,50),
					new SqlParameter("@Floor_sn", SqlDbType.Int,4),
					new SqlParameter("@Calibrate_sn", SqlDbType.Int,4),
					new SqlParameter("@Eq_id", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_Assets_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Date_Range", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Next_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Cp_Place", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note1", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Status", SqlDbType.Int,4),
					new SqlParameter("@Last_Cp_Log_sn", SqlDbType.Int,4)			};
            parameters[0].Value = Assets_sn;
            parameters[1].Value = Assts_no;
            parameters[2].Value = Assts_id;
            parameters[3].Value = Assts_name;
            parameters[4].Value = Assts_eq_id;
            parameters[5].Value = Assts_eq_name;
            parameters[6].Value = Assts_Quantity;
            parameters[7].Value = Assts_Customer;
            parameters[8].Value = Place_sn;
            parameters[9].Value = Place_Assets_sn;
            parameters[10].Value = Place_Assets_Detail_sn;
            parameters[11].Value = LastUser_sn;
            parameters[12].Value = LastChange_date;
            parameters[13].Value = Note;
            parameters[14].Value = SysNote;
            parameters[15].Value = Assts_Station;
            parameters[16].Value = Assts_Station_num;
            parameters[17].Value = Assts_Sttatus;
            parameters[18].Value = Place_name;
            parameters[19].Value = Floor;
            parameters[20].Value = Floor_sn;
            parameters[21].Value = Calibrate_sn;
            parameters[22].Value = Eq_id;
            parameters[23].Value = Eq_no;
            parameters[24].Value = Eq_name;
            parameters[25].Value = Eq_factory;
            parameters[26].Value = Eq_factory_no;
            parameters[27].Value = Eq_Assets_no;
            parameters[28].Value = Cp_Date_Range;
            parameters[29].Value = Last_Cp_Date;
            parameters[30].Value = Next_Cp_Date;
            parameters[31].Value = Cp_Place;
            parameters[32].Value = Cp_Type;
            parameters[33].Value = Cp_Note;
            parameters[34].Value = Cp_Note1;
            parameters[35].Value = Cp_Status;
            parameters[36].Value = Last_Cp_Log_sn;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PE2.Model.v_Calibrate GetModel(int Assets_sn, string Assts_no, string Assts_id, string Assts_name, string Assts_eq_id, string Assts_eq_name, int Assts_Quantity, string Assts_Customer, int Place_sn, string Place_Assets_sn, string Place_Assets_Detail_sn, int LastUser_sn, DateTime LastChange_date, string Note, string SysNote, string Assts_Station, int Assts_Station_num, int Assts_Sttatus, string Place_name, string Floor, int Floor_sn, int Calibrate_sn, string Eq_id, string Eq_no, string Eq_name, string Eq_factory, string Eq_factory_no, string Eq_Assets_no, string Cp_Date_Range, DateTime Last_Cp_Date, DateTime Next_Cp_Date, string Cp_Place, string Cp_Type, string Cp_Note, string Cp_Note1, int Cp_Status, int Last_Cp_Log_sn)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Assets_sn,Assts_no,Assts_id,Assts_name,Assts_eq_id,Assts_eq_name,Assts_Quantity,Assts_Customer,Place_sn,Place_Assets_sn,Place_Assets_Detail_sn,LastUser_sn,LastChange_date,Note,SysNote,Assts_Station,Assts_Station_num,Assts_Sttatus,Place_name,Floor,Floor_sn,Calibrate_sn,Eq_id,Eq_no,Eq_name,Eq_factory,Eq_factory_no,Eq_Assets_no,Cp_Date_Range,Last_Cp_Date,Next_Cp_Date,Cp_Place,Cp_Type,Cp_Note,Cp_Note1,Cp_Status,Last_Cp_Log_sn from v_Calibrate ");
            strSql.Append(" where Assets_sn=@Assets_sn and Assts_no=@Assts_no and Assts_id=@Assts_id and Assts_name=@Assts_name and Assts_eq_id=@Assts_eq_id and Assts_eq_name=@Assts_eq_name and Assts_Quantity=@Assts_Quantity and Assts_Customer=@Assts_Customer and Place_sn=@Place_sn and Place_Assets_sn=@Place_Assets_sn and Place_Assets_Detail_sn=@Place_Assets_Detail_sn and LastUser_sn=@LastUser_sn and LastChange_date=@LastChange_date and Note=@Note and SysNote=@SysNote and Assts_Station=@Assts_Station and Assts_Station_num=@Assts_Station_num and Assts_Sttatus=@Assts_Sttatus and Place_name=@Place_name and Floor=@Floor and Floor_sn=@Floor_sn and Calibrate_sn=@Calibrate_sn and Eq_id=@Eq_id and Eq_no=@Eq_no and Eq_name=@Eq_name and Eq_factory=@Eq_factory and Eq_factory_no=@Eq_factory_no and Eq_Assets_no=@Eq_Assets_no and Cp_Date_Range=@Cp_Date_Range and Last_Cp_Date=@Last_Cp_Date and Next_Cp_Date=@Next_Cp_Date and Cp_Place=@Cp_Place and Cp_Type=@Cp_Type and Cp_Note=@Cp_Note and Cp_Note1=@Cp_Note1 and Cp_Status=@Cp_Status and Last_Cp_Log_sn=@Last_Cp_Log_sn ");
            SqlParameter[] parameters = {
					new SqlParameter("@Assets_sn", SqlDbType.Int,4),
					new SqlParameter("@Assts_no", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_id", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_eq_name", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Quantity", SqlDbType.Int,4),
					new SqlParameter("@Assts_Customer", SqlDbType.NVarChar,500),
					new SqlParameter("@Place_sn", SqlDbType.Int,4),
					new SqlParameter("@Place_Assets_sn", SqlDbType.NVarChar,500),
					new SqlParameter("@Place_Assets_Detail_sn", SqlDbType.NVarChar,500),
					new SqlParameter("@LastUser_sn", SqlDbType.Int,4),
					new SqlParameter("@LastChange_date", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.NVarChar,500),
					new SqlParameter("@SysNote", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station", SqlDbType.NVarChar,500),
					new SqlParameter("@Assts_Station_num", SqlDbType.Int,4),
					new SqlParameter("@Assts_Sttatus", SqlDbType.Int,4),
					new SqlParameter("@Place_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Floor", SqlDbType.NVarChar,50),
					new SqlParameter("@Floor_sn", SqlDbType.Int,4),
					new SqlParameter("@Calibrate_sn", SqlDbType.Int,4),
					new SqlParameter("@Eq_id", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_factory_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Eq_Assets_no", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Date_Range", SqlDbType.NVarChar,50),
					new SqlParameter("@Last_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Next_Cp_Date", SqlDbType.DateTime),
					new SqlParameter("@Cp_Place", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Note1", SqlDbType.NVarChar,50),
					new SqlParameter("@Cp_Status", SqlDbType.Int,4),
					new SqlParameter("@Last_Cp_Log_sn", SqlDbType.Int,4)			};
            parameters[0].Value = Assets_sn;
            parameters[1].Value = Assts_no;
            parameters[2].Value = Assts_id;
            parameters[3].Value = Assts_name;
            parameters[4].Value = Assts_eq_id;
            parameters[5].Value = Assts_eq_name;
            parameters[6].Value = Assts_Quantity;
            parameters[7].Value = Assts_Customer;
            parameters[8].Value = Place_sn;
            parameters[9].Value = Place_Assets_sn;
            parameters[10].Value = Place_Assets_Detail_sn;
            parameters[11].Value = LastUser_sn;
            parameters[12].Value = LastChange_date;
            parameters[13].Value = Note;
            parameters[14].Value = SysNote;
            parameters[15].Value = Assts_Station;
            parameters[16].Value = Assts_Station_num;
            parameters[17].Value = Assts_Sttatus;
            parameters[18].Value = Place_name;
            parameters[19].Value = Floor;
            parameters[20].Value = Floor_sn;
            parameters[21].Value = Calibrate_sn;
            parameters[22].Value = Eq_id;
            parameters[23].Value = Eq_no;
            parameters[24].Value = Eq_name;
            parameters[25].Value = Eq_factory;
            parameters[26].Value = Eq_factory_no;
            parameters[27].Value = Eq_Assets_no;
            parameters[28].Value = Cp_Date_Range;
            parameters[29].Value = Last_Cp_Date;
            parameters[30].Value = Next_Cp_Date;
            parameters[31].Value = Cp_Place;
            parameters[32].Value = Cp_Type;
            parameters[33].Value = Cp_Note;
            parameters[34].Value = Cp_Note1;
            parameters[35].Value = Cp_Status;
            parameters[36].Value = Last_Cp_Log_sn;

            PE2.Model.v_Calibrate model = new PE2.Model.v_Calibrate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PE2.Model.v_Calibrate DataRowToModel(DataRow row)
        {
            PE2.Model.v_Calibrate model = new PE2.Model.v_Calibrate();
            if (row != null)
            {
                if (row["Assets_sn"] != null && row["Assets_sn"].ToString() != "")
                {
                    model.Assets_sn = int.Parse(row["Assets_sn"].ToString());
                }
                if (row["Assts_no"] != null)
                {
                    model.Assts_no = row["Assts_no"].ToString();
                }
                if (row["Assts_id"] != null)
                {
                    model.Assts_id = row["Assts_id"].ToString();
                }
                if (row["Assts_name"] != null)
                {
                    model.Assts_name = row["Assts_name"].ToString();
                }
                if (row["Assts_eq_id"] != null)
                {
                    model.Assts_eq_id = row["Assts_eq_id"].ToString();
                }
                if (row["Assts_eq_name"] != null)
                {
                    model.Assts_eq_name = row["Assts_eq_name"].ToString();
                }
                if (row["Assts_Quantity"] != null && row["Assts_Quantity"].ToString() != "")
                {
                    model.Assts_Quantity = int.Parse(row["Assts_Quantity"].ToString());
                }
                if (row["Assts_Customer"] != null)
                {
                    model.Assts_Customer = row["Assts_Customer"].ToString();
                }
                if (row["Place_sn"] != null && row["Place_sn"].ToString() != "")
                {
                    model.Place_sn = int.Parse(row["Place_sn"].ToString());
                }
                if (row["Place_Assets_sn"] != null)
                {
                    model.Place_Assets_sn = row["Place_Assets_sn"].ToString();
                }
                if (row["Place_Assets_Detail_sn"] != null)
                {
                    model.Place_Assets_Detail_sn = row["Place_Assets_Detail_sn"].ToString();
                }
                if (row["LastUser_sn"] != null && row["LastUser_sn"].ToString() != "")
                {
                    model.LastUser_sn = int.Parse(row["LastUser_sn"].ToString());
                }
                if (row["LastChange_date"] != null && row["LastChange_date"].ToString() != "")
                {
                    model.LastChange_date = DateTime.Parse(row["LastChange_date"].ToString());
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["SysNote"] != null)
                {
                    model.SysNote = row["SysNote"].ToString();
                }
                if (row["Assts_Station"] != null)
                {
                    model.Assts_Station = row["Assts_Station"].ToString();
                }
                if (row["Assts_Station_num"] != null && row["Assts_Station_num"].ToString() != "")
                {
                    model.Assts_Station_num = int.Parse(row["Assts_Station_num"].ToString());
                }
                if (row["Assts_Sttatus"] != null && row["Assts_Sttatus"].ToString() != "")
                {
                    model.Assts_Sttatus = int.Parse(row["Assts_Sttatus"].ToString());
                }
                if (row["Place_name"] != null)
                {
                    model.Place_name = row["Place_name"].ToString();
                }
                if (row["Floor"] != null)
                {
                    model.Floor = row["Floor"].ToString();
                }
                if (row["Floor_sn"] != null && row["Floor_sn"].ToString() != "")
                {
                    model.Floor_sn = int.Parse(row["Floor_sn"].ToString());
                }
                if (row["Calibrate_sn"] != null && row["Calibrate_sn"].ToString() != "")
                {
                    model.Calibrate_sn = int.Parse(row["Calibrate_sn"].ToString());
                }
                if (row["Eq_id"] != null)
                {
                    model.Eq_id = row["Eq_id"].ToString();
                }
                if (row["Eq_no"] != null)
                {
                    model.Eq_no = row["Eq_no"].ToString();
                }
                if (row["Eq_name"] != null)
                {
                    model.Eq_name = row["Eq_name"].ToString();
                }
                if (row["Eq_factory"] != null)
                {
                    model.Eq_factory = row["Eq_factory"].ToString();
                }
                if (row["Eq_factory_no"] != null)
                {
                    model.Eq_factory_no = row["Eq_factory_no"].ToString();
                }
                if (row["Eq_Assets_no"] != null)
                {
                    model.Eq_Assets_no = row["Eq_Assets_no"].ToString();
                }
                if (row["Cp_Date_Range"] != null)
                {
                    model.Cp_Date_Range = row["Cp_Date_Range"].ToString();
                }
                if (row["Last_Cp_Date"] != null && row["Last_Cp_Date"].ToString() != "")
                {
                    model.Last_Cp_Date = DateTime.Parse(row["Last_Cp_Date"].ToString());
                }
                if (row["Next_Cp_Date"] != null && row["Next_Cp_Date"].ToString() != "")
                {
                    model.Next_Cp_Date = DateTime.Parse(row["Next_Cp_Date"].ToString());
                }
                if (row["Cp_Place"] != null)
                {
                    model.Cp_Place = row["Cp_Place"].ToString();
                }
                if (row["Cp_Type"] != null)
                {
                    model.Cp_Type = row["Cp_Type"].ToString();
                }
                if (row["Cp_Note"] != null)
                {
                    model.Cp_Note = row["Cp_Note"].ToString();
                }
                if (row["Cp_Note1"] != null)
                {
                    model.Cp_Note1 = row["Cp_Note1"].ToString();
                }
                if (row["Cp_Status"] != null && row["Cp_Status"].ToString() != "")
                {
                    model.Cp_Status = int.Parse(row["Cp_Status"].ToString());
                }
                if (row["Last_Cp_Log_sn"] != null && row["Last_Cp_Log_sn"].ToString() != "")
                {
                    model.Last_Cp_Log_sn = int.Parse(row["Last_Cp_Log_sn"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Assets_sn,Assts_no,Assts_id,Assts_name,Assts_eq_id,Assts_eq_name,Assts_Quantity,Assts_Customer,Place_sn,Place_Assets_sn,Place_Assets_Detail_sn,LastUser_sn,LastChange_date,Note,SysNote,Assts_Station,Assts_Station_num,Assts_Sttatus,Place_name,Floor,Floor_sn,Calibrate_sn,Eq_id,Eq_no,Eq_name,Eq_factory,Eq_factory_no,Eq_Assets_no,Cp_Date_Range,Last_Cp_Date,Next_Cp_Date,Cp_Place,Cp_Type,Cp_Note,Cp_Note1,Cp_Status,Last_Cp_Log_sn ");
            strSql.Append(" FROM v_Calibrate ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Assets_sn,Assts_no,Assts_id,Assts_name,Assts_eq_id,Assts_eq_name,Assts_Quantity,Assts_Customer,Place_sn,Place_Assets_sn,Place_Assets_Detail_sn,LastUser_sn,LastChange_date,Note,SysNote,Assts_Station,Assts_Station_num,Assts_Sttatus,Place_name,Floor,Floor_sn,Calibrate_sn,Eq_id,Eq_no,Eq_name,Eq_factory,Eq_factory_no,Eq_Assets_no,Cp_Date_Range,Last_Cp_Date,Next_Cp_Date,Cp_Place,Cp_Type,Cp_Note,Cp_Note1,Cp_Status,Last_Cp_Log_sn ");
            strSql.Append(" FROM v_Calibrate ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM v_Calibrate ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Last_Cp_Log_sn desc");
            }
            strSql.Append(")AS Row, T.*  from v_Calibrate T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "v_Calibrate";
            parameters[1].Value = "Last_Cp_Log_sn";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

