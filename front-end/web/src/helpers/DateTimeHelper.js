import { format, parseISO } from "date-fns";

export function formatDateTime(dateTime) {
  return format(parseISO(dateTime), "dd/MM/yyyy '-' HH:mm:ss");
}
