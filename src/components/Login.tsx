import { Button, Card, Form, Input, Spin } from "antd";
import React from "react";
import { useEffect } from "react";
import { useHistory } from "react-router-dom";
import loginIcon from "../assets/icons/icons8_key_240px_1.png";
import { login } from "../store/actions/action.authentication";
import { LoginStatus } from "../store/slice.authentication";
import { useAppDispatch, useAppSelector } from "../store/hooks";

function Login() {
    const dispatch = useAppDispatch();
    const history = useHistory();
    const loginStatus = useAppSelector(s => s.authentication.loginStatus);
    useEffect(() => {
        if (loginStatus == LoginStatus.LOGIN_SUCCESS) {
            history.push("/");
        }
    }, [loginStatus]);
    const onFinish = (values: { username: string, password: string }) => {
        dispatch(login(values.username, values.password));
    }
    return (
        <div className="center" style={{ background: "#ECECEC", height: '100vh' }}>
            <Spin tip="Processing..." spinning={loginStatus == LoginStatus.LOGIN_REQUEST}>

                <Card title={
                    <div style={{ textAlign: "center" }}>
                        <b>Login  </b>
                        <img src={loginIcon} alt="login icon" width="16" height="16" />
                    </div>
                }
                    style={{ width: 300 }}
                    bordered>
                    <Form
                        name="login"
                        layout="vertical"
                        initialValues={{ remember: true }}
                        wrapperCol={{ span: 32 }}
                        onFinish={onFinish}
                    >
                        <Form.Item label="Username" name="username"
                            rules={
                                [{ required: true, message: "Please input username!" }]
                            }>
                            <Input />
                        </Form.Item>
                        <Form.Item label="Password" name="password"
                            rules={
                                [{ required: true, message: "Please input password!" }]
                            }>
                            <Input.Password />
                        </Form.Item>
                        {loginStatus == LoginStatus.LOGIN_FAIL && <p style={{ color: "red" }}>Username or password is incorrect!</p>}
                        <Form.Item>
                            <Button type="primary" htmlType="submit" style={{ width: '100%' }}>
                                Login
                            </Button>
                        </Form.Item>
                        <Form.Item>
                            <Button type="ghost" htmlType="button" style={{ width: '100%' }}>
                                New user? Register here
                            </Button>
                        </Form.Item>
                    </Form>
                </Card>
            </Spin>
        </div>
    );
}

export default Login;