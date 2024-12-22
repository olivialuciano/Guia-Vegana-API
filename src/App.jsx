import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from "./pages/HomePage/HomePage.jsx";
import Businesses from "./pages/Businesses/Businesses.jsx";

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/bussiness" element={<Businesses />} />
      </Routes>
    </Router>
  );
};

export default App;
