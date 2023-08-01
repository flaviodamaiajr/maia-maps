import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7295",
});

const apiPostCodes = axios.create({
  baseURL: "https://api.postcodes.io",
});

export { api, apiPostCodes };
