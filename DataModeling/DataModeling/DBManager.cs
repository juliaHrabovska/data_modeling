using DataModeling;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

public class DBManager
{
    static SqlConnection conection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Source\Repos\data_modeling\DataModeling\DataModeling\Database1.mdf;Integrated Security=True");
    static SqlCommand command = new SqlCommand();
    static SqlDataReader reader;

    public static void insert(DistributionInfo distributionInfo)
    {
        SqlCommand command = new SqlCommand("INSERT INTO Data_Modeling (id, autor, distribution, restoring) VALUES ('" + 
            distributionInfo.Id + "','" + distributionInfo.Autor + "','" + 
            convertToString(distributionInfo.Dots) + "','" + distributionInfo.Restoring + "')");
        command.ExecuteNonQuery();
        command.Clone();
       
    }

    public static List<DistributionInfo> getAll()
    {
        List<DistributionInfo> distributionInfo = new List<DistributionInfo>();
        SqlCommand command = new SqlCommand("SELECT id, autor, distribution, restoring FROM Data_Modeling");
        reader = command.ExecuteReader();
        long id;
        String autor;
        String distribution;
        String restoring;
        while(reader.HasRows)
        {
            while (reader.Read())
            {
                id = (long) reader.GetSqlInt64(0);
                autor = reader.GetString(1);
                distribution = reader.GetString(2);
                restoring = reader.GetString(3);

                List<Double> dots = getDotsFromString(distribution);
                distributionInfo.Add(new DistributionInfo(id, dots, autor, restoring));
            }
        }
        reader.Close();

        return distributionInfo;
    }

    public static DistributionInfo getById(long id)
    {
        SqlCommand command = new SqlCommand("SELECT id, autor, distribution, restoring FROM Data_Modeling WHERE id=" + id);
        reader = command.ExecuteReader();
        long id1 = 0;
        String autor = "";
        String distribution = "";
        String restoring = "";
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                id = (long)reader.GetSqlInt64(0);
                autor = reader.GetString(1);
                distribution = reader.GetString(2);
                restoring = reader.GetString(3);
            }
        }
        else
        {
            MessageBox.Show("Not found element", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        List<Double> dots = getDotsFromString(distribution);
        return new DistributionInfo(id1, dots, autor,  restoring);
    }

    private static List<Double> getDotsFromString(String dotsInString)
    {
        List<Double> dots = new List<Double>();
        String pattern = @"(;|\s)";
        var stringValues = Regex.Split(dotsInString, pattern);

        for (int j = 0; j < stringValues.Length; j++)
        {
            dots.Add(double.Parse(stringValues[j]));
        }
        return dots;
    }

    private static String convertToString(List<Double> dots)
    {
        StringBuilder sb = new StringBuilder();
        bool flag = false;
        foreach (double d in dots)
        {
            sb.Append(d);
            if (flag)
            {
                sb.Append(Environment.NewLine);
            }
            else
            {
                sb.Append(";");
            }
            flag = !flag;
        }

        return sb.ToString();
    }

}
