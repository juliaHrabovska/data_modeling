using System.Data.SqlClient;

public class DBManager
{
    SqlConnection conection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Source\Repos\data_modeling\DataModeling\DataModeling\Database1.mdf;Integrated Security=True");
    SqlCommand command = new SqlCommand();
    SqlDataReader reader;

    public static void insert(DistributionInfo distributionInfo)
    {
        SqlCommand command = new SqlCommand("INSERT INTO Data_Modeling (id, autor, distribution, restoring) VALUES ('" + 
            distributionInfo.getId() + "','" + distributionInfo.getAutor() + "','" + 
            convertToString(distributionInfo.getDots()) + "','" + distributionInfo.getRestoring() + "')");
        command.ExecuteQuery();
        command.Close();
        return true;
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
                id = reader.GetLong(0);
                autor = reader.GetString(1);
                distribution = reader.GetString(2);
                restoring = reader.GetString(3);

                List<Double> dots = getDotsFromString(distribution);
                distributionInfo.Add(new DistributionInfo(id, autor, dots, restoring));
            }
        }
        reader.Close();

        return distributionInfo;
    }

    public static DistributionInfo getById(long id)
    {
        SqlCommand command = new SqlCommand("SELECT id, autor, distribution, restoring FROM Data_Modeling WHERE id=" + id);
        reader = command.ExecuteReader();
        long id;
        String autor;
        String distribution;
        String restoring;
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                id = reader.GetLong(0);
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
        return new DistributionInfo(id, autor, dots, restoring);
    }

    private static List<Double> getDotsFromString(String dotsInString)
    {
        List<Double> dots = new List<Double>();
        string[] stringSeparators = new string[] { "\n" };
        var lines = dotsInString.Split(stringSeparators);

        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(';');

            for (int j = 0; j < values.Length; j++)
            {
                dots.Add(double.Parse(values[j]));
            }
        }
        return dots;
    }

    private static String convertToString(List<Double> dots)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(comboBox1.SelectedItem.ToString()).Append(";");
        sb.Append(DateTime.Today).Append(";");
        sb.Append(Environment.UserName).Append(Environment.NewLine);
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
