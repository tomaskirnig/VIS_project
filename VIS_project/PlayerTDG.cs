using System.Data;

public class PlayerGateway
{
    private readonly string _connectionString;

    public PlayerGateway(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable GetAll()
    {
        // SQL query to select all records from Players table
    }

    public DataRow GetById(int playerId)
    {
        // SQL query to select a record by PlayerId
    }

    public void Insert(string firstName, string lastName, DateTime dateOfBirth, string email, char gender, DateTime registrationDate, string country, bool gameReviewer)
    {
        // SQL query to insert a new record into Players table
    }

    public void Update(int playerId, string firstName, string lastName, DateTime dateOfBirth, string email, char gender, DateTime registrationDate, string country, bool gameReviewer)
    {
        // SQL query to update a record in Players table
    }

    public void Delete(int playerId)
    {
        // SQL query to delete a record from Players table
    }
}
