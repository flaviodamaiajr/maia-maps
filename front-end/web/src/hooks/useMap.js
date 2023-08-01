import { useContext } from "react";

import { MapContext } from "../contexts/MapContext";

export function useMap() {
  const context = useContext(MapContext);

  return context;
}
