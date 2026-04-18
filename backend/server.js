const express = require("express");
const cors = require("cors");

const app = express();

app.use(cors());
app.use(express.json());

const runRoutes = require("./routes/runRoutes");
app.use("/api/runs", runRoutes);

app.listen(3000, '0.0.0.0', () => {
  console.log("Server running on http://0.0.0.0:3000");
});