import { makeStyles } from "@material-ui/styles";

export default makeStyles((theme) => ({
  pageTitleContainer: {
    display: "flex",
    justifyContent: "space-between",
    marginBottom: theme.spacing(4),
    marginTop: theme.spacing(6),
  },
  title: {
    display: "flex",
    flexDirection: "column",
    justifyContent: "left",
    marginTop: theme.spacing(2),
  },
  typo: {
    color: theme.palette.text.hint,
    [theme.breakpoints.down("sm")]: {
      fontSize: 38,
    },
    [theme.breakpoints.down("xs")]: {
      fontSize: 32,
    },
  },
  button: {
    boxShadow: theme.customShadows.widget,
    textTransform: "none",
    "&:active": {
      boxShadow: theme.customShadows.widgetWide,
    },
  },
}));
