using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public class AdSetRepository: IAdSetRepository
    {
        DatabaseConnection DatabaseConnection = new DatabaseConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public void addAdSet(AdSet adSetToAdd)
        {
            DatabaseConnection.OpenConnection();
            string query = "INSERT INTO AdSet(Name, TargetAudience, AdAccountID) values (@name, @targetAudience, @AdAccountID)";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@name", adSetToAdd.name);
            command.Parameters.AddWithValue("@targetAudience", adSetToAdd.targetAudience);
            command.Parameters.AddWithValue("@AdAccountID", User.User.getInstance().Id);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public void deleteAdSet(AdSet adSetToDelete)
        {
            DatabaseConnection.OpenConnection();
            string query = "DELETE FROM AdSet WHERE ID=@adAccountId";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adAccountId", adSetToDelete.adSetId);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public void updateAdSet(AdSet adSetToUpdate)
        {
            DatabaseConnection.OpenConnection();
            string query = "UPDATE AdSet SET Name=@Name, TargetAudience=@audience";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@name", adSetToUpdate.name);
            command.Parameters.AddWithValue("@audience", adSetToUpdate.targetAudience);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();

        }

        public AdSet getAdSetByName(AdSet adSet)
        {
            DataSet dataSet = new DataSet();
            DatabaseConnection.OpenConnection();
            string query = "SELECT * FROM AdSet WHERE Name = @name";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@name", adSet.name);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                string id = dataRow["ID"].ToString();
                adSet.adSetId = id;
            }

            DatabaseConnection.CloseConnection();
            return adSet;
        }

        public void addAdToAdSet(AdSet adSet, Ad newAd)
        {
            DatabaseConnection.OpenConnection();
            string query = "UPDATE Ad SET AdSetID = @adSetID WHERE ID = @adID";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adSetID", adSet.adSetId);
            command.Parameters.AddWithValue("@adID", newAd.id);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public void removeAdFromAdSet(AdSet adSet, Ad adToRemove)
        {
            DatabaseConnection.OpenConnection();
            string query = "UPDATE Ad SET AdSetID = NULL WHERE ID = @adID";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adSetID", adSet.adSetId);
            command.Parameters.AddWithValue("@adID", adToRemove.id);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public List<AdSet> getAdSetsThatAreNotInCampaign()
        {
            List<AdSet> adSets = new List<AdSet>();
            DataSet dataSet = new DataSet();
            DatabaseConnection.OpenConnection();
            string query = "SELECT * FROM AdSet WHERE CampaignID IS NULL AND AdAccountID=@adAccountId";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adAccountId", User.User.getInstance().Id);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                string id = dataRow["ID"].ToString();
                string name = dataRow["Name"].ToString();
                string targetAudience = dataRow["TargetAudience"].ToString();
                AdSet adSet = new AdSet(id, name, targetAudience);
                adSets.Add(adSet);
            }
            DatabaseConnection.CloseConnection();
            return adSets;
        }

        public List<AdSet> getAdSetsInCampaign(string idToGet)
        {
            List<AdSet> adSets = new List<AdSet>();
            DataSet dataSet = new DataSet();
            DatabaseConnection.OpenConnection();
            string query = "SELECT * FROM AdSet WHERE CampaignID=@adAccountId";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adAccountId", idToGet);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                string id = dataRow["ID"].ToString();
                string name = dataRow["Name"].ToString();
                string targetAudience = dataRow["TargetAudience"].ToString();
                AdSet adSet = new AdSet(id, name, targetAudience);
                adSets.Add(adSet);
            }
            DatabaseConnection.CloseConnection();
            return adSets;
        }
    }
}
