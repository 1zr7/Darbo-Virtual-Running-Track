const db = require("../database/db");

function saveRun(run, callback) {
  const { user, distance, laps, time, pace } = run;

  db.run(
    `INSERT INTO runs (user, distance, laps, time, pace)
     VALUES (?, ?, ?, ?, ?)`,
    [user, distance, laps, time, pace],
    callback
  );
}

function getLeaderboard(callback) {
  db.all(
  `SELECT user, MAX(laps) as bestLaps
   FROM runs
   GROUP BY user
   ORDER BY bestLaps DESC
   LIMIT 10`,
  [],
  callback
  );
}

module.exports = { saveRun, getLeaderboard };