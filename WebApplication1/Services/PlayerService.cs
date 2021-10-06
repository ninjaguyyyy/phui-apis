using MongoDB.Driver;
using PhuiAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhuiAPIs.Services
{
  public class PlayerService
  {
    private readonly IMongoCollection<Player> playersCollection;
    public PlayerService(IDatabaseSettings databaseSettings)
    {
      var client = new MongoClient(databaseSettings.ConnectionString);
      var database = client.GetDatabase(databaseSettings.DatabaseName);

      playersCollection = database.GetCollection<Player>("players");
    }
    public List<Player> Get() =>
            playersCollection.Find(book => true).ToList();

    public Player Get(string id) =>
        playersCollection.Find<Player>(book => book.Id == id).FirstOrDefault();

    public Player Create(Player book)
    {
      playersCollection.InsertOne(book);
      return book;
    }

    public void Update(string id, Player bookIn) =>
        playersCollection.ReplaceOne(book => book.Id == id, bookIn);

    public void Remove(Player bookIn) =>
        playersCollection.DeleteOne(book => book.Id == bookIn.Id);

    public void Remove(string id) =>
        playersCollection.DeleteOne(book => book.Id == id);
  }
}
