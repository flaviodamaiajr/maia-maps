import { GlobalContext } from "./contexts";

import { Layout } from "./components/Layout";

function App() {
  return (
    <GlobalContext>
      <Layout />
    </GlobalContext>
  );
}

export default App;
