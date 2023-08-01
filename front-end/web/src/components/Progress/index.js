import { LinearProgress } from "@material-ui/core";

export function Progress({ isLoading }) {
  return <>{isLoading ? <LinearProgress /> : null}</>;
}
