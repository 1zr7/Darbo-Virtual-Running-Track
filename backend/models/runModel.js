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
    `SELECT user, MAX(distance) as bestDistance
     FROM runs
     GROUP BY user
     ORDER BY bestDistance DESC
     LIMIT 10`,
    [],
    callback
  );
}

module.exports = { saveRun, getLeaderboard };