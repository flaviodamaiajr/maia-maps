import React from "react";

// Context API
import { MapProvider } from "./MapContext";

export function GlobalContext({ children }) {
  return <MapProvider>{children}</MapProvider>;
}
