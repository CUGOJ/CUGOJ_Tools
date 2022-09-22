#! /bin/bash

thrift -gen netstd ../CUGOJ_Idl/base.thrift
thrift -gen netstd ../CUGOJ_Idl/common.thrift
thrift -gen netstd ../CUGOJ_Idl/oj_common.thrift
thrift -gen netstd ../CUGOJ_Idl/services/authentication.thrift
thrift -gen netstd ../CUGOJ_Idl/services/core.thrift
thrift -gen netstd ../CUGOJ_Idl/services/base.thrift
thrift -gen netstd ../CUGOJ_Idl/services/gateway.thrift
thrift -gen netstd ../CUGOJ_Idl/services/judger.thrift
