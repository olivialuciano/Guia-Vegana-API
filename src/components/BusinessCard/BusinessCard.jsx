// import React from "react";

// eslint-disable-next-line react/prop-types
const BusinessCard = ({ name, address, rating }) => {
  // Estilos embebidos
  const styles = {
    card: {
      border: "1px solid #ccc",
      borderRadius: "8px",
      padding: "16px",
      margin: "16px",
      width: "300px",
      boxShadow: "0 4px 6px rgba(0, 0, 0, 0.1)",
      textAlign: "center",
    },
    name: {
      fontSize: "24px",
      fontWeight: "bold",
      color: "#333",
    },
    address: {
      fontSize: "16px",
      color: "#777",
      margin: "8px 0",
    },
    stars: {
      color: "#FFD700",
    },
  };

  return (
    <div style={styles.card}>
      <div style={styles.name}>{name}</div>
      <div style={styles.address}>{address}</div>
      <div style={styles.stars}>
        {"★".repeat(rating)}
        {"☆".repeat(5 - rating)}
      </div>
    </div>
  );
};

export default BusinessCard;
