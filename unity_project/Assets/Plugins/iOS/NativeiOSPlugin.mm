//
//  NativeiOSPlugin.m
//  Unity-iPhone
//
//  Created by 강동욱 on 2018. 2. 8..
//
#import <GoogleSignIn/GoogleSignIn.h>
#import <Foundation/Foundation.h>
extern "C" void iOSPluginOpenGoogle(){
    GIDSignIn *a= [GIDSignIn sharedInstance];
    
    printf("instance is :%lu\n",(unsigned long)a);
    printf("delegate is :%lu\n",(unsigned long)[a delegate]);
    printf("UI delegate is :%lu\n",(unsigned long)[a uiDelegate]);
    
    NSLog(@"client id is :%@ \n",[a clientID]);
    NSLog(@"server client id is :%@ \n",[a serverClientID]);
    [[GIDSignIn sharedInstance] signIn];
}



