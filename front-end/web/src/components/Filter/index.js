import React from "react";

import Paper from "@material-ui/core/Paper";
import FormControl from "@material-ui/core/FormControl";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import ButtonGroup from "@material-ui/core/ButtonGroup";

import useStyles from "./styles";

// Hooks
import { useMap } from "../../hooks/useMap";

// Formik and Yup
import { useFormik } from "formik";
import * as yup from "yup";

export function Filter() {
  const classes = useStyles();

  const { setMessage, message, isLoading, getInformationsByPostcodes } =
    useMap();

  const validationSchema = yup.object({
    from: yup
      .string("Insert the postcode (from)")
      .required("Postcode From is required"),
    to: yup
      .string("Insert the postcode (to)")
      .required("Postcode To is required"),
  });

  const formik = useFormik({
    initialValues: {
      from: "",
      to: "",
    },
    validationSchema: validationSchema,
    onSubmit: (values) => {
      handleCalculateDistance(values);
    },
  });

  async function handleCalculateDistance({ from, to }) {
    await getInformationsByPostcodes(from, to, false);
  }

  function clearForm() {
    setMessage({ ...message, isVisible: false });
    formik.resetForm();
  }

  return (
    <Paper style={{ marginBottom: 5 }}>
      <form onSubmit={formik.handleSubmit} noValidate>
        <FormControl className={classes.formControl}>
          <TextField
            inputProps={{
              minLength: 1,
              maxLength: 15,
              style: {
                textTransform: "uppercase",
              },
            }}
            id="from"
            name="from"
            label="Postcode From"
            required
            autoComplete="none"
            value={formik.values.from}
            onChange={(e) => {
              formik.handleChange(e);
            }}
            error={formik.touched.from && Boolean(formik.errors.from)}
            helperText={formik.touched.from && formik.errors.from}
          />
          <TextField
            inputProps={{
              minLength: 1,
              maxLength: 15,
              style: {
                textTransform: "uppercase",
              },
            }}
            id="to"
            name="to"
            label="Postcode To"
            required
            autoComplete="none"
            value={formik.values.to}
            onChange={(e) => {
              formik.handleChange(e);
            }}
            error={formik.touched.to && Boolean(formik.errors.to)}
            helperText={formik.touched.to && formik.errors.to}
          />
          <div className={classes.buttonGroup}>
            <ButtonGroup disableElevation variant="contained">
              <Button type="submit" color="primary" disabled={isLoading}>
                {!isLoading ? "Calculate Distance" : "Waiting..."}
              </Button>
              <Button
                color="secondary"
                disabled={isLoading}
                onClick={() => clearForm()}
              >
                {!isLoading ? "Clear" : "Waiting..."}
              </Button>
            </ButtonGroup>
          </div>
        </FormControl>
      </form>
    </Paper>
  );
}
