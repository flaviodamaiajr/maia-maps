import { MapContainer, TileLayer, Marker, Polyline } from "react-leaflet";
import markerIconPng from "leaflet/dist/images/marker-icon.png";
import { Icon } from "leaflet";
import "./styles.css";

import { useMap } from "../../hooks/useMap";

export function Maps() {
  const { coords } = useMap();

  const { from, to } = coords;

  const iconConfig = new Icon({
    iconUrl: markerIconPng,
    iconSize: [25, 41],
    iconAnchor: [12, 41],
  });

  return (
    <MapContainer center={[51.560414, -0.116805]} zoom={3}>
      <TileLayer
        attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
      />
      <Marker position={[from.latitude, from.longitude]} icon={iconConfig} />
      <Marker position={[to.latitude, from.longitude]} icon={iconConfig} />
      <Polyline
        positions={[
          [from.latitude, from.longitude],
          [to.latitude, from.longitude],
        ]}
        color={"blue"}
      />
    </MapContainer>
  );
}
