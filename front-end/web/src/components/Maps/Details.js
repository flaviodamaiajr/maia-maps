import { makeStyles } from "@material-ui/core/styles";
import Paper from "@material-ui/core/Paper";
import Grid from "@material-ui/core/Grid";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";

// Components
import { Progress } from "../Progress";

// Hooks
import { useMap } from "../../hooks/useMap";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  maps: {
    padding: theme.spacing(1),
  },
  details: {
    padding: theme.spacing(1),
    textAlign: "center",
    color: theme.palette.text.secondary,
  },
  title: {
    fontSize: 14,
  },
}));

export function Details({ children }) {
  const classes = useStyles();

  const { isLoading, postcodeTargetDetails } = useMap();

  const NOT_CONTAIN = "N/C";

  const {
    details: {
      postcode,
      parish,
      latitude,
      longitude,
      northings,
      eastings,
      admin_ward,
      admin_district,
      region,
      country,
      parliamentary_constituency,
      european_electoral_region,
      ccg,
    },
    distance,
  } = postcodeTargetDetails;

  function formatDetails(value) {
    return value?.toString().replace(/^\s+|\s+$/gm, "") ? value : NOT_CONTAIN;
  }

  return (
    <>
      <Grid container spacing={1}>
        <Grid item xs={12} sm={12} md={8}>
          <Paper className={classes.maps}>{children}</Paper>
        </Grid>
        <Grid item xs>
          <Card className={classes.root}>
            <Progress isLoading={isLoading} />
            <CardContent>
              <Typography
                className={classes.details}
                variant="h5"
                component="h2"
              >
                Postcode Targeting Details
              </Typography>
              <Typography variant="body2" component="p">
                <strong>Postcode:</strong> {formatDetails(postcode)}
                <br />
                <strong>Parish:</strong> {formatDetails(parish)}
                <br />
                <strong>Latitude:</strong> {formatDetails(latitude)}
                <br />
                <strong>Longitude:</strong> {formatDetails(longitude)}
                <br />
                <strong>Northings:</strong> {formatDetails(northings)}
                <br />
                <strong>Eastings:</strong> {formatDetails(eastings)}
                <br />
                <strong>Ward:</strong> {formatDetails(admin_ward)}
                <br />
                <strong>District:</strong> {formatDetails(admin_district)}
                <br />
                <strong>Region:</strong> {formatDetails(region)}
                <br />
                <strong>Country:</strong> {formatDetails(country)}
                <br />
                <strong>Constituency:</strong>{" "}
                {formatDetails(parliamentary_constituency)}
                <br />
                <strong>European Electoral:</strong>{" "}
                {formatDetails(european_electoral_region)}
                <br />
                <strong>Clinical Commissioning:</strong> {formatDetails(ccg)}
                <br />
                <br />
                <strong>Distance:</strong> {distance?.km ?? 0} Km /{" "}
                {distance?.mi ?? 0} Mi
              </Typography>
            </CardContent>
          </Card>
        </Grid>
      </Grid>
    </>
  );
}
