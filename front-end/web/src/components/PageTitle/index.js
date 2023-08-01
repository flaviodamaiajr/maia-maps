import React from "react";
import { Typography } from "@material-ui/core";

// styles
import useStyles from "./styles";

export function PageTitle({ title }) {
  const classes = useStyles();

  return (
    <>
      <div className={classes.pageTitleContainer}>
        <div className={classes.title}>
          <Typography className={classes.typo} variant="h1" size="sm">
            {title}
          </Typography>
        </div>
      </div>
    </>
  );
}
