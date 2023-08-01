import React from "react";
import Alert from "@material-ui/lab/Alert";
import AlertTitle from "@material-ui/lab/AlertTitle";
import { useStyles } from "./styles";
import { useMap } from "../../hooks/useMap";

export function DescriptionAlert() {
  const classes = useStyles();

  const { message } = useMap();

  return (
    <>
      {message.isVisible ? (
        <div className={classes.root}>
          <Alert variant="filled" severity={message.type}>
            <AlertTitle>{message.title}</AlertTitle>
            {message.content}
          </Alert>
        </div>
      ) : null}
    </>
  );
}
