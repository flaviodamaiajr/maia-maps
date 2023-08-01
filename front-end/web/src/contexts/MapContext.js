import React, { createContext, useState, useEffect } from "react";

import { api, apiPostCodes } from "../services/api";

export const MapContext = createContext();

export function MapProvider({ children }) {
  const [searchHistories, setSearchHistories] = useState([]);
  const [coords, setCoords] = useState({
    from: { postcode: "", latitude: 0, longitude: 0 },
    to: { postcode: "", latitude: 0, longitude: 0 },
    isFromSearchHistories: false,
  });
  const [postcodeTargetDetails, setPostcodeTargetDetails] = useState({
    details: {},
    distance: { km: 0, mi: 0 },
  });
  const [isLoading, setIsLoading] = useState(false);
  const [message, setMessage] = useState({
    type: "",
    title: "",
    content: "",
    isVisible: false,
  });

  async function getInformationsByPostcodes(
    postcodeFrom,
    postcodeTo,
    isFromSearchHistories
  ) {
    try {
      setIsLoading(true);
      setMessage({ ...message, isVisible: false });
      const response = await apiPostCodes.post("/postcodes", {
        postcodes: [postcodeFrom, postcodeTo],
      });

      const {
        data: { result },
      } = response;

      if (result[0].result === null || result[1].result === null) {
        setMessage({
          ...message,
          type: "error",
          title: "Ops!",
          content: "Address not found, check the postcodes and try again!",
          isVisible: true,
        });
        return;
      }

      setPostcodeTargetDetails({
        ...postcodeTargetDetails,
        details: result[1].result,
      });

      setCoords({
        to: {
          postcode: postcodeTo,
          latitude: result[0].result.latitude,
          longitude: result[0].result.longitude,
        },
        from: {
          postcode: postcodeFrom,
          latitude: result[1].result.latitude,
          longitude: result[1].result.longitude,
        },
        isFromSearchHistories,
      });
    } catch (e) {
      setMessage({
        ...message,
        type: "error",
        title: "Ops!",
        content: "An unexpected error occurred in the request.",
        isVisible: true,
      });
    } finally {
      setIsLoading(false);
    }
  }

  async function getSearchHistoryById(id) {
    try {
      setIsLoading(true);
      setMessage({ ...message, isVisible: false });
      const { data, status } = await api.get(`/v1/SearchHistory/${id}`);

      if (status === 200) {
        const {
          postcodeFrom,
          postcodeTo,
          distance: { kilometers, miles },
        } = data;

        const response = await apiPostCodes.post("/postcodes", {
          postcodes: [postcodeFrom, postcodeTo],
        });

        const {
          data: { result },
        } = response;

        setPostcodeTargetDetails({
          ...postcodeTargetDetails,
          details: result[1].result,
          distance: { km: kilometers, mi: miles },
        });

        setCoords({
          to: {
            postcode: postcodeTo,
            latitude: result[0].result.latitude,
            longitude: result[0].result.longitude,
          },
          from: {
            postcode: postcodeFrom,
            latitude: result[1].result.latitude,
            longitude: result[1].result.longitude,
          },
          isFromSearchHistories: true,
        });
      }
    } catch (e) {
    } finally {
      setIsLoading(false);
    }
  }

  async function calculateDistance() {
    const { from, to } = coords;
    console.log(from, to);
    try {
      const { status, data } = await api.post("/v1/SearchHistory", {
        postcode: {
          from: from.postcode,
          to: to.postcode,
        },
        coordinatesFrom: {
          latitude: from.latitude,
          longitude: from.longitude,
        },
        coordinatesTo: {
          latitude: to.latitude,
          longitude: to.longitude,
        },
      });

      if (status === 201) {
        const { kilometers, miles } = data.data;

        setPostcodeTargetDetails({
          ...postcodeTargetDetails,
          distance: { km: kilometers, mi: miles },
        });

        setMessage({
          ...message,
          type: "success",
          title: "Ahoooy!",
          content: "We found the customer address based on the postcode.",
          isVisible: true,
        });

        await fetchSearchHistories();
      }
    } catch (e) {
      alert(e);
    }
  }

  async function fetchSearchHistories() {
    try {
      setIsLoading(true);
      const response = await api.get("/v1/SearchHistory");

      const {
        data: { items },
      } = response;

      setSearchHistories(items);
    } catch (e) {
      alert(e);
    } finally {
      setIsLoading(false);
    }
  }

  useEffect(() => {
    (async function () {
      await fetchSearchHistories();
    })();
  }, []);

  useEffect(() => {
    if (
      !coords.isFromSearchHistories &&
      coords.from.latitude !== 0 &&
      coords.from.longitude !== 0
    ) {
      (async function () {
        await calculateDistance();
      })();
    }
  }, [coords]);

  return (
    <MapContext.Provider
      value={{
        searchHistories,
        setCoords,
        coords,
        isLoading,
        setMessage,
        message,
        getInformationsByPostcodes,
        postcodeTargetDetails,
        getSearchHistoryById,
      }}
    >
      {children}
    </MapContext.Provider>
  );
}
