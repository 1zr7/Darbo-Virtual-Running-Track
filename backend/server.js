const express = require("express");
const cors = require("cors");

const app = express();

app.use(cors());
app.use(express.json());

const runRoutes = require("./routes/runRoutes");
app.use("/api/runs", runRoutes);

app.listen(3000, () => {
  console.log("Server running on http://localhost:3000");
});