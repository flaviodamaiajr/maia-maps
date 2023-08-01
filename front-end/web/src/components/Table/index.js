import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Toolbar,
  Typography,
  Button,
} from "@material-ui/core";
import ExploreIcon from "@material-ui/icons/Explore";

import { formatDateTime } from "../../helpers/DateTimeHelper";

import useStyles from "./styles";

import { Progress } from "../Progress";

// Hooks
import { useMap } from "../../hooks/useMap";

export function SearchHistory() {
  const classes = useStyles();

  const { searchHistories, isLoading, getSearchHistoryById } = useMap();

  async function handleViewLocation(id) {
    try {
      await getSearchHistoryById(id);
    } catch (e) {
      alert(e);
    }
  }

  return (
    <div style={{ marginTop: 10 }}>
      <Paper>
        <Progress isLoading={isLoading} />
        <Toolbar style={{ backgroundColor: "#6366f1" }}>
          <Typography
            style={{ color: "#FFF" }}
            variant="h6"
            id="tableTitle"
            component="div"
          >
            Latest search
          </Typography>
        </Toolbar>
        <TableContainer component={Paper}>
          <Table className={classes.table} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Postcode From {">"} To</TableCell>
                <TableCell align="right">Distance in Kilometers</TableCell>
                <TableCell align="right">Distance in Miles</TableCell>
                <TableCell align="right">Created At</TableCell>
                <TableCell></TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {searchHistories?.map((row) => (
                <TableRow key={row.id}>
                  <TableCell component="th" scope="row">
                    {row.postCode.from} {">"} {row.postCode.to}
                  </TableCell>
                  <TableCell align="right">
                    {row.distance.kilometers} Km
                  </TableCell>
                  <TableCell align="right">{row.distance.miles} Mi</TableCell>
                  <TableCell align="right">
                    {formatDateTime(row.createdAt)}
                  </TableCell>
                  <TableCell align="center">
                    <Button
                      variant="contained"
                      color="primary"
                      className={classes.button}
                      startIcon={<ExploreIcon />}
                      onClick={() => handleViewLocation(row.id)}
                      disabled={isLoading}
                    >
                      {!isLoading ? "View" : "Wait..."}
                    </Button>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Paper>
    </div>
  );
}
