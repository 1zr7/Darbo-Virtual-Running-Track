const express = require("express");
const router = express.Router();
const { saveRun, getLeaderboard } = require("../models/runModel");

router.post("/save", (req, res) => {
  const run = req.body;

  saveRun(run, (err) => {
    if (err) {
      res.status(500).json({ error: err.message });
    } else {
      res.json({ message: "Run saved successfully" });
    }
  });
});

router.get("/leaderboard", (req, res) => {
  getLeaderboard((err, rows) => {
    if (err) {
      res.status(500).json({ error: err.message });
    } else {
      res.json(rows);
    }
  });
});

module.exports = router;