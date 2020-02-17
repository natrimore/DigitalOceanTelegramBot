﻿using DigitalOceanBot.MongoDb.Models;
using MongoDB.Driver;
using System;

namespace DigitalOceanBot.MongoDb
{
    public class SessionRepository : IRepository<Session>
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public SessionRepository(string connectionString)
        {
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase("DigitalOceanBot");
        }

        public void Create(Session entity)
        {
            _database.GetCollection<Session>("Sessions").InsertOne(entity);
        }

        public Session Get(int userId)
        {
            return _database.GetCollection<Session>("Sessions").Find(u => u.UserId == userId).FirstOrDefault();
        }

        public void Update(int userId, Action<Session> action)
        {
            var session = _database.GetCollection<Session>("Sessions")
                        .Find(u => u.UserId == userId)
                        .FirstOrDefault();

            action(session);

            _database.GetCollection<Session>("Sessions").ReplaceOne(u => u.UserId == session.UserId, session);
        }

        public void Delete(int userId)
        {
            _database.GetCollection<HandlerCallback>("Sessions").DeleteOne(h => h.UserId == userId);
        }
    }
}