import React from "react";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import IconButton from '@material-ui/core/IconButton';
import Tooltip from '@material-ui/core/Tooltip';
import GitHub from '@material-ui/icons/GitHub';
// style
import useStyles from "./styles";

export function Header() {
  var classes = useStyles();

  return (
    <div className={classes.root}>
      <AppBar position="fixed">
        <Toolbar>
          <Typography variant="h6" weight="medium" className={classes.logotype}>
            🗺️ Maia Maps
          </Typography>
          <Tooltip title="My Github - @flaviodamaiajr">
            <IconButton
              aria-label="Github - @flaviodamaiajr"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={() => { window.open("https://github.com/flaviodamaiajr", "_blank") }}
              color="inherit"
            >
              <GitHub />
            </IconButton>
          </Tooltip>
        </Toolbar>
      </AppBar>
    </div>
  );
}
