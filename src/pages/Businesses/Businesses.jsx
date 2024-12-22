import React from "react";
import { Link } from "react-router-dom";
import BusinessCard from "../../components/BusinessCard/BusinessCard";
import { useEffect, useState } from "react";

const Businesses = () => {
  const [businesses, setBusinesses] = useState([]);

  useEffect(() => {
    // Llamada a la API
    fetch("https://guiavegana.somee.com/api/Business")
      .then((response) => response.json())
      .then((data) => setBusinesses(data))
      .catch((error) => console.error("Error al obtener negocios:", error));
  }, []);

  return (
    <div>
      <Link to="/">Go Back</Link>
      <h1 style={{ textAlign: "center", margin: "20px 0" }}>Negocios</h1>
      <div
        style={{ display: "flex", flexWrap: "wrap", justifyContent: "center" }}
      >
        {businesses.map((business) => (
          <BusinessCard
            key={business.id}
            name={business.name}
            address={business.address}
            rating={business.rating}
          />
        ))}
      </div>
    </div>
  );
};

export default Businesses;
