import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  formControl: {
    display: "flex",
    flexDirection: "row",
    flexFlow: "column wrap",
    minWidth: 100,
    paddingLeft: 0,
    margin: 10,
    "& .MuiTextField-root": {
      margin: theme.spacing(1),
      width: "30ch",
    },
    "& .MuiButtonGroup-root": {
      margin: theme.spacing(2),
    },
  },
  inputs: {
    display: "flex",
    justifyContent: "center",
  },
}));

export default useStyles;
