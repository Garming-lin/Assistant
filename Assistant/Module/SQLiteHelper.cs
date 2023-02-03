using System;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.IO;

namespace Assistant.Module
{
    /// <summary>
    /// SQLite数据库
    /// 需引用：System.Data.SQLite.dll
    /// </summary>
    public class SQLiteHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectString 
        {
            get;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sDbFile">SQLite数据库文件绝对路径</param>
        /// <exception cref="FileNotFoundException">抛出该异常表示数据库文件不存在</exception>
        public SQLiteHelper(string sDbFile)
        {
            if(!File.Exists(sDbFile))
            {
                throw new FileNotFoundException(sDbFile + "\n文件不存在！");
            }
            ConnectString = string.Format("Data Source={0};Integrated Security=no", sDbFile);
        }

        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="sCmd">SQL命令</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int ExcuteSql(string sCmd)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sCmd, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SQLiteException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询SELECT命令
        /// </summary>
        /// <param name="sCmd">SQL查询SELECT命令</param>
        /// <returns></returns>
        public DataTable ExcuteQuery(string sCmd)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectString))
            {
                DataTable dtResult = new DataTable();
                try
                {
                    connection.Open();
                    SQLiteDataAdapter command = new SQLiteDataAdapter(sCmd, connection);
                    command.Fill(dtResult);
                }
                catch (SQLiteException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
                return dtResult;
            }
        }

        /// <summary>
        /// 执行更新UPDATE命令
        /// </summary>
        /// <param name="sCmd">SQL更新UPDATE命令</param>
        /// <returns></returns>
        public int ExcuteUpdate(string sCmd)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sCmd, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SQLiteException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行插入INSERT命令
        /// </summary>
        /// <param name="sCmd">SQL插入INSERT命令</param>
        /// <returns></returns>
        public int ExcuteInsert(string sCmd)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sCmd, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SQLiteException ex)
                    {
                        connection.Close();
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
