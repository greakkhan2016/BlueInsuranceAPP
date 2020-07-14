import React, { useEffect, useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import {
  TableRow,
  TableHead,
  TableContainer,
  TableCell,
  TableBody,
  Table,
  Paper,
} from "@material-ui/core/";
import Typography from "@material-ui/core/Typography";
import axios from "axios";

const useStyles = makeStyles((theme) => ({
  paper: {
    padding: theme.spacing(1),
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
    backgroundColor: theme.palette.background.paper,
    border: "2px solid #000",
    boxShadow: theme.shadows[5],
  },
}));

export default function SimpleTable() {
  const [result, setResults] = useState([]);
  const classes = useStyles();
  useEffect(() => {
    axios
      .get("https://localhost:44395/Student/ListAllStudentInSystem")
      .then((response) => {
        console.log(response);
        setResults(response.data);
      });
  }, []);

  return (
    <div>
      <Typography variant="h4">Students Registered in the System</Typography>
      <TableContainer
        className={classes.paper}
        component={Paper}
        size="small"
        width="small"
      >
        <Table size="small" align="center" aria-label="Students in the System">
          <TableHead>
            <TableRow>
              <TableCell align="center">FirstName</TableCell>
              <TableCell align="center">LastName</TableCell>
              <TableCell align="center">Date Of Birth</TableCell>
              <TableCell align="center">Address</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {result.map((row) => (
              <TableRow key={row.name}>
                <TableCell align="center">{row.firstName}</TableCell>
                <TableCell align="center">{row.lastName}</TableCell>
                <TableCell align="center">{row.dateOfBirth}</TableCell>
                <TableCell align="center">
                {row.address1} {row.address2} {row.address3}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </div>
  );
}
