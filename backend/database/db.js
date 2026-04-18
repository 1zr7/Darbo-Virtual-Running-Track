const sqlite3 = require("sqlite3").verbose();

const db = new sqlite3.Database("./runs.db");

db.serialize(() => {
  db.run(`
    CREATE TABLE IF NOT EXISTS runs (
      id INTEGER PRIMARY KEY AUTOINCREMENT,
      user TEXT,
      distance REAL,
      laps INTEGER,
      time REAL,
      pace TEXT
    )
  `);
});

module.exports = db;