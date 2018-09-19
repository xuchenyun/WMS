using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.IO;
using System.Drawing;


namespace Common.Helper
{

    public class PublicSetModel<T> where T : new()
    {

        #region 由窗体的属性给实体类赋值
        /// <summary>
        /// 由窗体的属性给实体类赋值
        /// </summary>
        /// <param name="app"></param>
        /// <param name="obj"></param>
        public static void GetModelValueFromForm(Form app, T obj)
        {
            PropertyInfo[] property = typeof(T).GetProperties();
            FieldInfo[] fieldsInfor = app.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (PropertyInfo per in property)
            {
                FieldInfo filed = fieldsInfor.Where(p => p.Name == per.Name).LastOrDefault();
                if (filed != null)
                {
                    object value= GetControlValue(filed, app);
                    switch (per.PropertyType.ToString())
                    {
                        case "System.String":
                            per.SetValue(obj, SqlInput.ChangeNullToValueString(value, ""), null);
                            break;
                        case "System.Boolean":
                            per.SetValue(obj, SqlInput.ChangeBoolToValue(value, false), null);
                            break;
                        case "System.Decimal":
                            per.SetValue(obj, SqlInput.ChangeNullToDecimal(value, 0), null);
                            break;
                        case "System.Double":
                            per.SetValue(obj, SqlInput.ChangeNullToDouble(value, 0), null);
                            break;
                        case "System.Int32":
                            per.SetValue(obj, SqlInput.ChangeNullToInt(value, 0), null);
                            break;
                        case "System.DateTime":
                            per.SetValue(obj, SqlInput.ChangeDateTimeToValue(value, DateTime.Now), null);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 由窗体的属性给实体类赋值,控件名=前缀+实体类属性
        /// </summary>
        /// <param name="app">窗体</param>
        /// <param name="obj">实体类</param>
        /// <param name="frontName">控件命名前缀</param>
        public static void GetModelValueFromForm(Form app, T obj, string frontName)
        {
            PropertyInfo[] property = typeof(T).GetProperties();
            FieldInfo[] fieldsInfor = app.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (PropertyInfo per in property)
            {
                FieldInfo filed = fieldsInfor.Where(p => p.Name == (frontName+per.Name)).LastOrDefault();
                if (filed != null)
                {
                    object value = GetControlValue(filed, app);
                    switch (per.PropertyType.ToString())
                    {
                        case "System.String":
                            per.SetValue(obj, SqlInput.ChangeNullToValueString(value, ""), null);
                            break;
                        case "System.Boolean":
                            per.SetValue(obj, SqlInput.ChangeBoolToValue(value, false), null);
                            break;
                        case "System.Decimal":
                            per.SetValue(obj, SqlInput.ChangeNullToDecimal(value, 0), null);
                            break;
                        case "System.Double":
                            per.SetValue(obj, SqlInput.ChangeNullToDouble(value, 0), null);
                            break;
                        case "System.Int32":
                            per.SetValue(obj, SqlInput.ChangeNullToInt(value, 0), null);
                            break;
                        case "System.DateTime":
                            per.SetValue(obj, SqlInput.ChangeDateTimeToValue(value, DateTime.Now), null);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion

        #region 通过获取控件的类型返回值
        /// <summary>
        /// 通过获取控件的类型返回值
        /// </summary>
        /// <param name="filed">反射对象变量</param>
        /// <param name="app">窗体实例</param>
        /// <returns></returns>
        private static object GetControlValue(FieldInfo filed, Form app)
        {
            object returnValue = new object();
            switch (filed.FieldType.ToString())
            {
                case "System.Windows.Forms.TextBox":
                    returnValue = ((TextBox)filed.GetValue(app)).Text.Trim();
                    break;
                //case "Moresoft.Controls.TextBoxEx":
                //    returnValue = ((Moresoft.Controls.TextBoxEx)filed.GetValue(app)).Text.Trim();
                //    break;
                case "System.Windows.Forms.ComboBox":
                    returnValue = ((ComboBox)filed.GetValue(app)).SelectedValue;
                    break;              
                case "System.Windows.Forms.DateTimePicker":
                    returnValue = ((DateTimePicker)filed.GetValue(app)).Value;
                    break;               
                case "System.Windows.Forms.NumericUpDown":
                    returnValue = ((NumericUpDown)filed.GetValue(app)).Value;
                    break;
                case "System.Windows.Forms.Label":
                    returnValue = ((Label)filed.GetValue(app)).Text;
                    break;               
                default:
                    break;
            }
            return returnValue;
        }
        #endregion
        #region  从GridView中获取数据生成对应实体类集合
        /// <summary>
        /// 从GridView中获取数据生成对应实体类集合
        /// </summary>
        /// <param name="dgvr">GridView数据源</param>
        /// <returns></returns>
        public static List<T> GetListByGridView(DataGridView dgvr)
        {
            List<T> bindColl = new List<T>();
            int maxCount = dgvr.Rows.Count;
            if (dgvr.AllowUserToAddRows)
            {
                maxCount = maxCount - 1;
            }
            for (int i = 0; i < maxCount; i++)
            {
                T obj = new T();
                PropertyInfo[] protyInColl = obj.GetType().GetProperties();
                foreach (PropertyInfo per in protyInColl)
                {
                    for (int j = 0; j < dgvr.Columns.Count; j++)
                    {
                        if (per.Name.ToLower() == dgvr.Columns[j].DataPropertyName.ToLower())
                        {
                            switch (per.PropertyType.ToString())
                            {
                                case "System.String":
                                    per.SetValue(obj, SqlInput.ChangeNullToValueString(dgvr.Rows[i].Cells[j].Value, ""), null);
                                    break;
                                case "System.Boolean":
                                    per.SetValue(obj, SqlInput.ChangeBoolToValue(dgvr.Rows[i].Cells[j].Value, true), null);
                                    break;
                                case "System.Decimal":
                                    per.SetValue(obj, SqlInput.ChangeNullToDecimal(dgvr.Rows[i].Cells[j].Value, 0), null);
                                    break;
                                case "System.Double":
                                    per.SetValue(obj, SqlInput.ChangeNullToDouble(dgvr.Rows[i].Cells[j].Value, 0), null);
                                    break;
                                case "System.Int32":
                                    per.SetValue(obj, SqlInput.ChangeNullToInt(dgvr.Rows[i].Cells[j].Value, 0), null);
                                    break;
                                case "System.DateTime":
                                    per.SetValue(obj, SqlInput.ChangeDateTimeToValue(dgvr.Rows[i].Cells[j].Value, DateTime.MinValue), null);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                bindColl.Add(obj);
            }
            return bindColl;
        }
        #endregion

        #region 创建更新语句
        public static string GetUpdateSQL(T model)
        {
            T obj = new T();
            PropertyInfo[] protyInColl = obj.GetType().GetProperties();
            var types = typeof(T);
            MethodInfo[] methods = types.GetMethods();
            PropertyInfo[] Propertys = model.GetType().GetProperties();
            string primaryKey = string.Empty;
            string primaryKeyValue = string.Empty;
            string Value = string.Empty;
            int rowIndex = 0;
            foreach (var property in Propertys)
            {
                rowIndex++;
                if (rowIndex == 1)
                {
                    primaryKey = property.Name;
                    try
                    {
                        primaryKeyValue = property.GetValue(model, null).ToString();
                    }
                    catch
                    {
                        throw new Exception("实体类第一个字段必须为主键，主键必须有值！");
                    }
                    continue;
                }
                if (Value == string.Empty)
                {
                    try
                    {
                        Value = property.Name + string.Format("='{0}'", SqlInput.InputString(property.GetValue(model, null).ToString()));
                    }
                    catch
                    {
                        Value = property.Name + string.Format("=null");
                    }
                }
                else
                {
                    try
                    {
                        Value +=","+ property.Name + string.Format("='{0}'", SqlInput.InputString( property.GetValue(model, null).ToString()));
                    }
                    catch
                    {
                        Value += "," + property.Name + string.Format("=null");
                    }
                }

              

            }
            return string.Format("update {0} set {1} where {2}='{3}'", types.Name,  Value,primaryKey,primaryKeyValue);
        }
        #endregion

        #region 创建插入语句
        public static string GetInsertSQL(T model)
        {
            T obj = new T();
            PropertyInfo[] protyInColl = obj.GetType().GetProperties();
            var types = typeof(T);
            MethodInfo[] methods = types.GetMethods();
            PropertyInfo[] Propertys = model.GetType().GetProperties();
            string Proper = string.Empty;
            string Value = string.Empty;
            int rowIndex = 0;
            foreach (var property in Propertys)
            {
                    rowIndex++;
                 
                    if (Proper == string.Empty)
                    {
                        Proper = property.Name;
                    }
                    else
                    {
                        Proper +=","+ property.Name;
                    }

                if (rowIndex == 1)
                {
                    Value = "getnewid('" + types.Name + "')";
                }
                else
                {
                    try
                    {
                        Value += string.Format(",'{0}'", SqlInput.InputString(property.GetValue(model, null).ToString()));
                    }
                    catch
                    {
                        Value += string.Format(",null");
                    }
                }

            }
            return string.Format("insert into {0} ({1}) values ({2})",types.Name,Proper,Value);
        }
        #endregion

      

      

        #region 复制一个泛型实体类
        /// <summary>
        /// 复制一个泛型实体类
        /// </summary>
        /// <param name="obj">要COPY的实体类</param>
        /// <returns>返回一个COPY的类</returns>
        public static T CopyT(T obj)
        {
            T copyObj = new T();
            PropertyInfo[] property = typeof(T).GetProperties();
            foreach (PropertyInfo per in property)
            {
                object value= per.GetValue(obj,null);
                per.SetValue(copyObj, value, null);
            }
            return copyObj;
        }
        #endregion

        #region 复制一个泛型类的相同值到另一个实体类(杜绝NULL值)
        /// <summary>
        /// 复制一个泛型类的相同值到另一个实体类(杜绝NULL值)
        /// </summary>
        /// <param name="modelObj">需要赋值的实体类</param>
        /// <param name="obj">要复制值的泛型类</param>
        public static void CopyValueOtherModel(object modelObj,T obj)
        {
            if (modelObj == null || obj == null)
            {
                return;
            }
            PropertyInfo[] propertyT = typeof(T).GetProperties();
            PropertyInfo[] propertyObj = modelObj.GetType().GetProperties();
            foreach (PropertyInfo per in propertyT)
            {
                var property= propertyObj.LastOrDefault(p => p.Name == per.Name);
                if(property!=null)
                {
                    object value = per.GetValue(obj, null);

                    //判断复制值的实体类的属性的具体类型
                    switch (property.PropertyType.ToString())
                    {
                        case "System.String":                                               //字符串类型
                            property.SetValue(modelObj, SqlInput.ChangeNullToValueString(value, ""), null);
                            break;                                                      
                        case "System.Boolean":                                              //BOOL类型
                            property.SetValue(modelObj, SqlInput.ChangeBoolToValue(value, true), null);
                            break;
                        case "System.Decimal":                                              //单精度类型
                            property.SetValue(modelObj, SqlInput.ChangeNullToDecimal(value, 0), null);
                            break;
                        case "System.Double":
                            property.SetValue(modelObj, SqlInput.ChangeNullToDouble(value, 0), null);
                            break;
                        case "System.Int32":                                                //整型
                            property.SetValue(modelObj, SqlInput.ChangeNullToInt(value, 0), null);
                            break;
                        case "System.DateTime":
                            property.SetValue(modelObj, SqlInput.ChangeDateTimeToValue(value, DateTime.Now), null);
                            break;
                        case "System.Byte[]":
                            if (value != null && value != DBNull.Value)
                            {
                                property.SetValue(modelObj, (byte[])value, null);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion

        #region 将DataRow转换成需求的实体类 
        /// <summary>
        /// 将DataRow转换成需求的实体类 
        /// </summary>
        /// <param name="dr">Datarow数据源</param>
        public static T GetTByDataRow(DataRow dr)
        {
            T tase = new T();
            if (dr == null)
            {
                return tase;
            }

            PropertyInfo[] myFields = tase.GetType().GetProperties();
            foreach (DataColumn dc in dr.Table.Columns)
            {
                string name = dc.ColumnName.ToUpper();
                var felds = myFields.Where(p => p.Name.ToUpper() == name).LastOrDefault();
                if (felds == null)
                {
                    continue;
                }
                switch (felds.PropertyType.ToString())
                {
                    case "System.String":
                        felds.SetValue(tase, SqlInput.ChangeNullToValueString(dr[felds.Name], ""), null);
                        break;
                    case "System.Boolean":
                        felds.SetValue(tase, SqlInput.ChangeBoolToValue(dr[felds.Name], true), null);
                        break;
                    case "System.Decimal":
                        felds.SetValue(tase, SqlInput.ChangeNullToDecimal(dr[felds.Name], 0), null);
                        break;
                    case "System.Double":
                        felds.SetValue(tase, SqlInput.ChangeNullToDouble(dr[felds.Name], 0), null);
                        break;
                    case "System.Int32":
                        felds.SetValue(tase, SqlInput.ChangeNullToInt(dr[felds.Name], 0), null);
                        break;
                    case "System.DateTime":
                        felds.SetValue(tase, SqlInput.ChangeDateTimeToValue(dr[felds.Name], DateTime.MinValue), null);
                        break;
                    case "System.Byte[]":
                        if (dr[felds.Name] != null && dr[felds.Name] != DBNull.Value)
                        {
                            felds.SetValue(tase, (byte[])dr[felds.Name], null);
                        }
                        break;
                    default:
                        break;
                }
            }
            return tase;
        }
        #endregion

        #region 将DataGridViewRow转换成需求的实体类 
        /// <summary>
        /// 将DataGridViewRow转换成需求的实体类 
        /// </summary>
        /// <param name="dr">Datarow数据源</param>
        public static T GetTByDataGridViewRow(DataGridViewRow dr)
        {
            T tase = new T();
            if (dr == null)
            {
                return tase;
            }

            PropertyInfo[] myFields = tase.GetType().GetProperties();
            foreach (DataGridViewCell cell in dr.Cells)
            {
                string name = cell.OwningColumn.Name.ToUpper();
                var felds = myFields.Where(p => p.Name.ToUpper() == name).LastOrDefault();
                if (felds == null)
                {
                    continue;
                }
                switch (felds.PropertyType.ToString())
                {
                    case "System.String":
                        felds.SetValue(tase, SqlInput.ChangeNullToValueString(cell.Value, ""), null);
                        break;
                    case "System.Boolean":
                        felds.SetValue(tase, SqlInput.ChangeBoolToValue(cell.Value, true), null);
                        break;
                    case "System.Decimal":
                        felds.SetValue(tase, SqlInput.ChangeNullToDecimal(cell.Value, 0), null);
                        break;
                    case "System.Double":
                        felds.SetValue(tase, SqlInput.ChangeNullToDouble(cell.Value, 0), null);
                        break;
                    case "System.Int32":
                        felds.SetValue(tase, SqlInput.ChangeNullToInt(cell.Value, 0), null);
                        break;
                    case "System.DateTime":
                        felds.SetValue(tase, SqlInput.ChangeDateTimeToValue(cell.Value, DateTime.MinValue), null);
                        break;
                    case "System.Byte[]":
                        if (cell.Value != null && cell.Value != DBNull.Value)
                        {
                            felds.SetValue(tase, (byte[])cell.Value, null);
                        }
                        break;
                    default:
                        break;
                }
            }
            return tase;
        }
        #endregion

    }

}
