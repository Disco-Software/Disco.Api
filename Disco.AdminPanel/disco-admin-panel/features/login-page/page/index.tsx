import styled from "@emotion/styled";
import { Button, colors, TextField } from "@mui/material";
import { Box } from "@mui/system";
import { Form } from "react-final-form";

export const LogInPage: React.FC = () => {
  return (
    <div>
    <style jsx>
        {'body {background-color: #29193E} form{background-color: white}'}
    </style>
    <form>
     <Box
        display={"flex"} 
        flexDirection={"column"}
        maxWidth={400}
        justifyContent={"center"}
        alignItems={"center"}
        margin="auto"
            marginTop={20}
            padding={3}
            borderRadius={5}
            boxShadow={'5px 5px 10px rgba(28, 20, 45, 1)'}
            sx={{
                ':hover': {
                    boxShadow: '5px 5px 10px rgba(28, 20, 45, 1)'
                }
            }}>
        <img src={"images/logo.png"} alt="logo" width={48} height={48}/>
        <TextField margin="normal" type={"email"} placeholder="E-mail Adress"/>
        <TextField margin="normal" type={"password"} placeholder="Password"/>
        <Button>Log In</Button>
     </Box>
    </form>
    </div>
  );
};

const StyledButton = styled(Button)`
  background: red;
`;

const FlexBox = styled.div`
  display: flex;
`;
