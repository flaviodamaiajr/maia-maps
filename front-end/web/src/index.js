import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import Themes from "./themes";
import { ThemeProvider } from "@material-ui/styles";
import { CssBaseline } from "@material-ui/core";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <ThemeProvider theme={Themes.default}>
    <CssBaseline />
    <App />
  </ThemeProvider>
);
