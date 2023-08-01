import Container from "@material-ui/core/Container";

// styles
import useStyles from "./styles";

// components
import { Header } from "../Header";
import { PageTitle } from "../PageTitle";
import { Filter } from "../Filter";
import { Maps } from "../Maps";
import { SearchHistory } from "../Table";
import { DescriptionAlert } from "../Alert";
import { Details } from "../Maps/Details";

export function Layout() {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Header />
      {/* Content */}
      <div className={classes.content}>
        <Container>
          <PageTitle title="Distance between two addresses" />
          <DescriptionAlert />
          <Filter />
          <Details>
            <Maps />
          </Details>
          <SearchHistory />
        </Container>
      </div>
    </div>
  );
}
